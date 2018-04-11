using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QMyFirstOutlookAddIn
{
    public class Rand
    {
        [DllImport("MSVCRT.DLL")]
        public static extern IntPtr rand();
    }
    public class QCalcPrimeNumber
    {
        public QlogInfo LogInfo { get; set; }
        public async Task CalculatePrimeNumberAsync(int maxPrimeNumber)
        {
            LogInfo = new QlogInfo();
            LogInfo.startTime = DateTime.Now;
            
            await Task.Run(() =>
            {
                            Calc1(maxPrimeNumber);
            });
        }

        //Calculation method comment
        //Calculate Prime Numbers
        public void Calc1(int maxPrimeNumber)
        {
            
            bool isPrimeNumber = false;
            int calculatedAmountOfPrimeNumbers = 0;
            // Calculate Prime Number 
            for (int i = 2; i < maxPrimeNumber; i++)
            {
                isPrimeNumber = true;
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        isPrimeNumber = false;
                        break;
                    }
                }

                // Add calculated Prime Number to LogInfo
                if (isPrimeNumber)
                {
                    calculatedAmountOfPrimeNumbers++;
                    LogInfo.PrimeNumber = i;
                    LogInfo.claculateAmountOfPrimeNumbers = calculatedAmountOfPrimeNumbers;
                    LogInfo.calculatedPrimeNumberTime = DateTime.Now;
                }
                Thread.Sleep(100);
            }
        }
    }

    public class QlogInfo
    {
        public DateTime startTime { get; set; }
        public DateTime calculatedPrimeNumberTime { get; set; }
        public int claculateAmountOfPrimeNumbers { get; set; }
        public int PrimeNumber { get; set; }

    }
    public class QLogging
    {
        private string path = @"c:\temp\QMyOutlookAddInLog.txt";
        public QLogging()
        {
            //Creare first log
            if (!File.Exists(path))
            {
                if (!Directory.Exists(Path.GetDirectoryName(path)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(path));
                }

                using (FileStream fs = File.Create(path))
                {
                    Byte[] info = Encoding.ASCII.GetBytes("QMyFirstOutlookAddIn first run at " + DateTime.Now.ToString() + Environment.NewLine.ToString());
                    fs.Write(info, 0, info.Length);
                }
            }
        }

        public void LogData(QlogInfo info)
        {
            //Log main data
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine("Logging was activated at {0}, there were calculated {1} prime numbers at {2}. Calculated number is {3}",
                    info.startTime.ToString(),
                    info.claculateAmountOfPrimeNumbers.ToString(),
                    info.calculatedPrimeNumberTime.ToString(),
                    info.PrimeNumber.ToString()
                    );
            }
        }

        public void StartLog()
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine("Logging was started at {0}", DateTime.Now.ToString());
            }
        }
        public void EndLog()
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine("Logging was ended at {0}", DateTime.Now.ToString());
            }
        }
    }
}