using System;
using System.Collections.Generic;
using System.Text;

namespace Automatic_Service.Services
{
    public static class MathService
    {

        public static List<double> getOutliers(List<double> input)
        {
            List<double> output = new List<double>();
            List<double> data1 = new List<double>();
            List<double> data2 = new List<double>();
            input.Sort();
            if (input.Count % 2 == 0)
            {
                data1 = input.GetRange(0, input.Count / 2);
                data2 = input.GetRange(input.Count / 2, (input.Count) - (input.Count / 2));
            }
            else
            {
                data1 = input.GetRange(0, input.Count / 2);
                data2 = input.GetRange(input.Count / 2 + 1, input.Count-1);
            }

            double q1 = getMedian(data1);
            double q3 = getMedian(data2);
             double iqr = q3 - q1;
            double lowerFence = q1 - 3 * iqr;
            double upperFence = q3 + 3 * iqr;
            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] < lowerFence || input[i] > upperFence)
                    output.Add(input[i]);
            }

            return output;

        }


        private static double getMedian(List<double> data)
        {
            if (data.Count % 2 == 0)
                return ((data[data.Count / 2]) + (data[data.Count / 2 - 1])) / 2;
            else
                return data[data.Count / 2];
        }
    }
}
