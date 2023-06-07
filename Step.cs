using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeMaker2
{
    public class Step : Recipe
    {
        /*creating a constructor and mutating instance fields using the values passed into the constructor
         * This code was obtained from StackOverflow
         * written by SWeko
         * available at: https://stackoverflow.com/questions/12138221/does-not-contain-a-constructor-that-takes-0-arguments
         */
        public Step(string descriptionOfStep, int dummyValue)
        : base(descriptionOfStep, dummyValue) { }

    }
}
