using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yolov5Net.Scorer;
using Yolov5Net.Scorer.Models.Abstract;

namespace ObjectDetection1.Test
{
    public class CYoloModel : YoloModel
    {
        public override int Width { get; set; } = 640;
        public override int Height { get; set; } = 640;
        public override int Depth { get; set; } = 3;
        public override int Dimensions { get; set; } = 85;

        public override int[] Strides { get; set; } = new int[] { 8, 16, 32 };

        public override int[][][] Anchors { get; set; } = new int[][][]
        {
            new int[][] { new int[] { 010, 13 }, new int[] { 016, 030 }, new int[] { 033, 023 } },
            new int[][] { new int[] { 030, 61 }, new int[] { 062, 045 }, new int[] { 059, 119 } },
            new int[][] { new int[] { 116, 90 }, new int[] { 156, 198 }, new int[] { 373, 326 } }
        };
        public override int[] Shapes { get; set; } = new int[] { 80, 40, 20 };

        public override float Confidence { get; set; } = 0.20f;
        public override float MulConfidence { get; set; } = 0.25f;
        public override float Overlap { get; set; } = 0.45f;

        public override string[] Outputs { get; set; } = new[] { "output" };
        public override List<YoloLabel> Labels { get; set; } = new List<YoloLabel>()
        {
            new YoloLabel { Id = 1, Name = "10C"},
            new YoloLabel { Id = 2, Name = "10D"},
new YoloLabel { Id = 3, Name = "10H"},
new YoloLabel { Id = 4, Name = "10S"},
new YoloLabel { Id = 5, Name = "2C"},
new YoloLabel { Id = 6, Name = "2D"},
new YoloLabel { Id = 7, Name = "2H"},
new YoloLabel { Id = 8, Name = "2S"},
new YoloLabel { Id = 9, Name = "3C"},
new YoloLabel { Id = 10, Name = "3D"},
new YoloLabel { Id = 11, Name = "3H"},
new YoloLabel { Id = 12, Name = "3S"},
new YoloLabel { Id = 13, Name = "4C"},
new YoloLabel { Id = 14, Name = "4D"},
new YoloLabel { Id = 15, Name = "4H"},
new YoloLabel { Id = 16, Name = "4S"},
new YoloLabel { Id = 17, Name = "5C"},
new YoloLabel { Id = 18, Name = "5D"},
new YoloLabel { Id = 19, Name = "5H"},
new YoloLabel { Id = 20, Name = "5S"},
new YoloLabel { Id = 21, Name = "6C"},
new YoloLabel { Id = 22, Name = "6D"},
new YoloLabel { Id = 23, Name = "6H"},
new YoloLabel { Id = 24, Name = "6S"},
new YoloLabel { Id = 25, Name = "7C"},
new YoloLabel { Id = 26, Name = "7D"},
new YoloLabel { Id = 27, Name = "7H"},
new YoloLabel { Id = 28, Name = "7S"},
new YoloLabel { Id = 29, Name = "8C"},
new YoloLabel { Id = 30, Name = "8D"},
new YoloLabel { Id = 31, Name = "8H"},
new YoloLabel { Id = 32, Name = "8S"},
new YoloLabel { Id = 33, Name = "9C"},
new YoloLabel { Id = 34, Name = "9D"},
new YoloLabel { Id = 35, Name = "9H"},
new YoloLabel { Id = 36, Name = "9S"},
new YoloLabel { Id = 37, Name = "AC"},
new YoloLabel { Id = 38, Name = "AD"},
new YoloLabel { Id = 39, Name = "AH"},
new YoloLabel { Id = 40, Name = "AS"},
new YoloLabel { Id = 41, Name = "JC"},
new YoloLabel { Id = 42, Name = "JD"},
new YoloLabel { Id = 43, Name = "JH"},
new YoloLabel { Id = 44, Name = "JS"},
new YoloLabel { Id = 45, Name = "KC"},
new YoloLabel { Id = 46, Name = "KD"},
new YoloLabel { Id = 47, Name = "KH"},
new YoloLabel { Id = 48, Name = "KS"},
new YoloLabel { Id = 49, Name = "QC"},
new YoloLabel { Id = 50, Name = "QD"},
new YoloLabel { Id = 51, Name = "QH"},
new YoloLabel { Id = 52, Name = "QS"}
        };


        public override bool UseDetect { get; set; } = true;
    }
}
