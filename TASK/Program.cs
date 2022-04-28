using System;
using System.Linq;
using System.Collections.Generic;

namespace Task
{
    public class Program
    {
        public static void Main(){
            SwitchBoardSimulator switchBoard = new SwitchBoardSimulator();
            switchBoard.CreateSwitchBoardSimulator();
            switchBoard.DisplaySwitchBoardSimulator();
        }    
    }
}