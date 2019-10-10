using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Delegates
{
    public class Delegates
    {
        //define the delegate type, returns a float, requires two floats as input
        public delegate float FloatOpDelegate(float f0, float f1);

        //methods must have the same parameter and return types
        public float FloatAdd(float f0, float f1)
        {
            float result = f0 + f1;
            return (result);
        }

        public float FloatMultiply(float f0, float f1)
        {
            float result = f0 * f1;
            return (result);
        }

        //declares a field "fod" of type FloatOpDelegate
        public FloatOpDelegate fod;

        vod Awake()
        {
            //assigns the FloatAdd method to fod (so fod is the same as FloatAdd()
            fod = FloatAdd;
            
            fod(2, 3); //returns 5

            fod = FloatMultiply;

            fod(2, 3); //returns 6

            fod(2, 3);
        }

        //multicasting allows you to do more than one method at once
        void Start()
        {
            //assign both FloatAdd and FloatMultiply methods to fod, to run them both at once with the same parameters
            fod = FloatAdd
            fod += FloatMultiply
            
            //makes sure fod is not null before running
            if (fod != null)
            {
                //returns both the sum and product, so 5 and 6
                float result = fod(3, 4);
                //returns only 12 because it was the last method to run
                print(result);
            }
        }
    }
}