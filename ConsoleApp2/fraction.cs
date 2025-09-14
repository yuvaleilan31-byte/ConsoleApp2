using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class fraction
    {
        private int numerator { get;set;}
        private int denominator;

        public fraction(int numerator, int denominator)
        {
            this.numerator = numerator;
            if (denominator == 0) 
                this.denominator = 1;
            else
                this.denominator = denominator;
        }
        public double Calculate()
        {
            return this.numerator * 1.0 / this.denominator;
        }
        public int Div()
        {
           
            return (this.numerator % this.denominator);
        }

        public int Denominator
        {
            get
            { return this.denominator; }
            set
            {
                if (value != 0) { 
                        this.denominator = value;
                }
                
            }
        }



    }
}
