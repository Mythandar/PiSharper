using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PiSharper
{
    public enum BCMPin
    {
        //Pin 2
        Two = 2,

        //Pin 3
        Three = 3,

        //Pin 4
        Four = 4,

        //Pin 14
        Fourteen = 14,

        //Pin 17
        Seventeen = 17,

        //Pin 15
        Fifteen = 15,

        //Pin 18
        Eighteen = 18,

        //Pin 27
        TwentySeven = 27,

        //Pin 22
        Twentytwo = 22,

        //pin 23
        TwentyThree = 23,

        //pin 24
        TwentyFour = 24,

        //pin 10
        Ten = 10,

        //pin 9
        Nine = 9,
        
        //Pin 11
        Eleven = 11,

        //Pin 25
        TwentyFive = 25,

        //Pin 8
        Eight = 8,

        //Pin 7
        Seven = 7,
    
        //Pin 5
        Five = 5,

        //Pin 6
        Six = 6,
        
        //Pin 12
        Twelve = 12,

        //Pin 13
        Thirteen = 13,

        //Pin 19
        Nineteen = 19,

        //Pin 16
        Sixteen = 16,

        //Pin 26
        TwentySix = 26,

        //Pin 20
        Twenty = 20,

        //Pin 21
        TwentyOne = 21,
    }
    
    
    public enum PhysicalPin
    {
        //Everything has to end up refering to the BCM pin number,
        //to simplify the code it uses the bcm pin number assigned to that physical pin

        //Physical pin 3 = bcm pin 2
        Three = 2,

        //Physical pin 5 = bcm pin 3
        Five = 3,

        //Physical pin 7 = bcm pin 4
        Seven = 4,

        //Physical pin 8 = bcm pin 14
        Eight = 14,

        //Physical pin 10 = bcm pin 15
        Ten = 15,
        
        //Physical pin 11 = bcm pin 17
        Eleven = 17,

        //Physical pin 12 = bcm pin 18
        Twelve = 18,

        //Physical pin 13 = bcm pin 27
        Thirteen = 27,

        //Physical pin 15 = bcm pin 22
        fifteen = 22,

        //Physical pin 16 = bcm pin 23
        Sixteen = 23,

        //Physical pin 18 = bcm pin 24
        Eighteen = 24,

        //Physical pin 19 = bcm pin 10
        Ninteen = 10,

        //Physical pin 21 = bcm pin 9
        Twentyone = 9,

        //Physical pin 22 = bcm pin 25
        TwentyTwo = 25,

        //Physical pin 23 = bcm pin 11
        TwentyThree = 11,

        //Physical pin 24 = bcm pin 8
        TwentyFour = 8,

        //Physical pin 26 = bcm pin 7
        TwentySix = 7,

        //Physical pin 29 = bcm pin 5
        TwentyNine = 5,

        //Physical pin 31 = bcm pin 6
        ThirtyOne = 6,

        //Physical pin 32 = bcm pin 12
        ThirtyTwo = 12,

        //Physical pin 33 = bcm pin 13
        ThirtyThree = 13,

        //Physical pin 35 = bcm pin 19
        ThirtyFive = 19,

        //Physical pin 36 = bcm pin 16
        ThirtySix = 16,

        //Physical pin 37 = bcm pin 26
        ThirtySeven = 26,

        //Physical pin 38 = bcm pin 20
        ThirtyEight = 20,

        //Physical pin 40 = bcm pin 21
        Fourty = 21,
    }
    
}



