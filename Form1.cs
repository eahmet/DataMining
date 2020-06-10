using DevExpress.Diagram.Core;
using DevExpress.XtraDiagram;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DataMiningForm
{
    public partial class Form1 : Form
    {
        private static List<ProcessStep> _processStepList = new List<ProcessStep>();
        private static List<Flow> _flowList = new List<Flow>();
        private readonly Random _rnd = new Random();
        public Form1()
        {
            InitializeComponent();
           
        }
        private void DataMine_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;
            short.TryParse(txtReduce.Text, out short reduceStep);
            short.TryParse(txtDistance.Text, out short stepDistance);
            using (var fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = "Excel files (*.xls)|*.xls|Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                fileDialog.FilterIndex = 2;
                fileDialog.RestoreDirectory = true;
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = fileDialog.FileName;
                    var mineData = ReadExcel(filePath);
            
                    MineData(reduceStep,stepDistance,mineData);
                }
            }
        }

        private static List<MineClass> ReadExcel(string path)
        {
            try
            {
                var mineDataList = new List<MineClass>();
                var worksheet = new Aspose.Cells.Workbook(path).Worksheets[0];
                var row = 1;
                const int column = 0;
                while (true)
                {
                    var cell = worksheet.Cells[row, column];

                    if (cell.Value == null)
                        break;
                    mineDataList.Add(new MineClass
                    {
                        CaseId = worksheet.Cells[row, 1].IntValue,
                        Activity = worksheet.Cells[row, 15].StringValue,
                        EventDate = Convert.ToDateTime(worksheet.Cells[row, 8].StringValue),
                        Costs = 0,
                        Resource = worksheet.Cells[row, 11].StringValue
                    });
                    row++;
                }

                return mineDataList;
            }
            catch (Exception)
            {
                var jsonString = File.ReadAllText("Data.json");
                var mineData = JsonConvert.DeserializeObject<List<MineClass>>(jsonString, new JsonSerializerSettings
                {
                    Converters = new List<JsonConverter>()
                        {new IsoDateTimeConverter {DateTimeFormat = "dd-MM-yyyy:HH.mm"}},
                    Error = HandleDeserializationError,
                    MissingMemberHandling = MissingMemberHandling.Ignore,
                    StringEscapeHandling = StringEscapeHandling.EscapeHtml
                });

                return mineData;
            }
        }

        private void CreateDiagram()
        {
            diagram1.Items.Clear();
            
            foreach (var item in _processStepList.Select(processStep => new DiagramShape
            {
                Height = 100,
                Width = 100,
                Shape = BasicShapes.Rectangle,
                Tag = processStep,
                Content = processStep.Name
            }))
            {
                diagram1.Items.Add(item);
            }

            foreach (var flow in _flowList)
            {
                var connector = new DiagramConnector
                {
                    BeginItem = diagram1.Items.FirstOrDefault(x=>x.Tag==_processStepList.FirstOrDefault(y=>y.Id==flow.FromProcessStep)), 
                    EndItem = diagram1.Items.FirstOrDefault(x=>x.Tag==_processStepList.FirstOrDefault(y=>y.Id==flow.ToProcessStep)),
                    Appearance = { BorderColor = Color.FromArgb(_rnd.Next(256), _rnd.Next(256), _rnd.Next(256))}
                };
                
                diagram1.Items.Add(connector);    
            }
            diagram1.ApplySugiyamaLayout();

            
        }
        
        private void MineData(int reduceStep,int stepDistance,List<MineClass> mineData)
        {
            var activityList = new List<string>();
            activityList.AddRange(mineData.GroupBy(x=>x.Activity).Select(x=>x.Key).ToList());
            var activityDictionary = new Dictionary<string,List<string>>();
            foreach (var activity in activityList)
            {
                if(activityDictionary.Values.Any(d => d.Contains(activity))) continue;
                foreach (var tActivity in activityList)
                {
                    var distance = StringUtils.CalculateDistance(activity, tActivity);
                    if (stepDistance >= distance)
                    {
                        if (activityDictionary.ContainsKey(activity))
                        {
                            activityDictionary[activity].Add(tActivity);
                        }
                        else
                        {
                            if (!activityDictionary.Values.Any(d => d.Contains(tActivity)))
                            {
                                activityDictionary.Add(activity,new List<string>{tActivity});
                            }
                        }
                    }
                }
            }
            

            var caseNumber = mineData.GroupBy(x=>x.CaseId).Select(x=>x.Key).ToList();
            var processStepList = new List<ProcessStep>();
            var flowList = new List<Flow>();
            var startActivity = string.Empty;
            var endActivity = string.Empty;
            var multipleStartActivity = false;
            var multipleEndActivity = false;
            foreach (var caseNo in caseNumber)
            {
                var caseActivities = mineData.Where(x=>x.CaseId==caseNo).OrderBy(x=>x.EventDate).ToList();
                if (string.IsNullOrEmpty(startActivity)) 
                    startActivity = caseActivities.First().Activity;
                else
                {
                    if (!startActivity.Equals(caseActivities.First().Activity)) multipleStartActivity = true;
                }
                if (string.IsNullOrEmpty(endActivity)) 
                    endActivity = caseActivities.Last().Activity;
                else
                {
                    if (!endActivity.Equals(caseActivities.Last().Activity)) multipleEndActivity = true;
                }

            }
            if (multipleStartActivity)
                processStepList.Add(new ProcessStep
                {
                    Activity = "Start",
                    Cost = 0,
                    ModelKey = "Start",
                    Name = "Start",
                    Id = 1
                });
            foreach (var caseNo in caseNumber)
            {
                var caseActivities = mineData.Where(x=>x.CaseId==caseNo).OrderBy(x=>x.EventDate).ToList();
                foreach (var activities in caseActivities)
                {
                    var step = activityDictionary.FirstOrDefault(d => d.Value.Contains(activities.Activity));
                    var processStep = new ProcessStep
                    {
                        Activity = step.Key,
                        ModelKey = step.Key,
                        Name = step.Key,
                        Id = processStepList.Count + 1
                    };
                    if (!processStepList.Any(x => x.Name.Equals(step.Key))) processStepList.Add(processStep);
                }

            }

            if(multipleEndActivity)
                processStepList.Add(new ProcessStep
                {
                    Activity="End",
                    Cost=0,
                    ModelKey="End",
                    Name="End",
                    Id = processStepList.Count + 1
                });
            foreach (var caseNo in caseNumber)
            {
                var caseActivities = mineData.Where(x => x.CaseId == caseNo).OrderBy(x => x.EventDate).ToList();
                for (int i = 0; i < caseActivities.Count; i++)
                {
                    if (caseActivities.Count - 1 > i)
                    {
                        var fromStep = activityDictionary.FirstOrDefault(d => d.Value.Contains(caseActivities[i].Activity));
                        var toStep = activityDictionary.FirstOrDefault(d => d.Value.Contains(caseActivities[i + 1].Activity));
                        var fromProcessStep =
                            processStepList.FirstOrDefault(x => x.Name.Equals(fromStep.Key));
                        var toProcessStep =
                            processStepList.FirstOrDefault(x => x.Name.Equals(toStep.Key));
                        if (fromProcessStep == null || toProcessStep == null) continue;

                        if (!flowList.Any(x =>
                            x.FromProcessStep == fromProcessStep.Id && x.ToProcessStep == toProcessStep.Id))
                        {
                            flowList.Add(new Flow
                            {
                                FromProcessStep = fromProcessStep.Id,
                                ToProcessStep = toProcessStep.Id
                            });
                        }

                    }
                    else
                    {
                        var fromProcessStep =
                            processStepList.FirstOrDefault(x => x.Name.Equals(caseActivities[caseActivities.Count - 1].Activity));
                        var toProcessStep =processStepList.FirstOrDefault(x => x.Name.Equals("End"));
                        if (fromProcessStep == null || toProcessStep == null) continue;
                        if (!flowList.Any(x => x.FromProcessStep == fromProcessStep.Id && x.ToProcessStep == toProcessStep.Id))
                        {
                            flowList.Add(new Flow
                            {
                                FromProcessStep = fromProcessStep.Id,
                                ToProcessStep = toProcessStep.Id
                            });
                        }
                    }
                }
            }

            _flowList = flowList;
            _processStepList = processStepList;
            CreateDiagram();
        }

        private static void HandleDeserializationError(object sender, Newtonsoft.Json.Serialization.ErrorEventArgs errorArgs)
        {
            var currentError = errorArgs.ErrorContext.Error.Message;
            errorArgs.ErrorContext.Handled = true;
        }

    }
}
