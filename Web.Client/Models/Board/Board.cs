using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Client.Models.Board
{
    public class Board
    {
        public string Activity { get; set; }
        public double Accessibility { get; set; }
        public string Type { get; set; }
        public int Participants { get; set; }
        public int Price { get; set; }
        public string Key { get; set; }
    }
}
