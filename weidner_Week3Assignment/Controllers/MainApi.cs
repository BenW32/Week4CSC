using Microsoft.AspNetCore.Mvc;

namespace weidner_Week3Assignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainApi : ControllerBase
    {
     

        [HttpPost(Name = "GetWeatherForecast")]
        public ActionResult<List<string>> IntListWork(List<int> lint)
        {

            List<string> sList = new List<string>();
            double sum = 0;
            double counter = 0;
            double mean = 0; // average
            
            lint.Sort();
          
            double standardDeviation = 0;
            int index = 0;
            double topNumberTotal = 0;
            int jCounter = 0;
            
            counter = 0;
            foreach(int i in lint)
            {
                topNumberTotal = 0;
                counter++;
                sum = sum + i;
                mean = sum / counter;
                jCounter = 0;
                //foreach loop calculates top top value but only up to current number in list
                foreach (int j in lint)
                {
                    jCounter = jCounter + 1;
                   if (jCounter <= counter)
                    {
                        topNumberTotal = Math.Pow((j - mean), 2) + topNumberTotal;
                    }
                }
              
                standardDeviation = Math.Sqrt((topNumberTotal/(8-1)));
                if (standardDeviation == 0)
                {
                    sList.Add("List too small");
                }
                else
                {
                    sList.Add("Elements: " + counter + ": Current standard deviation: " + standardDeviation);
                }
                
                index = index + 1;
            }

            return sList;
        }
    }
}
