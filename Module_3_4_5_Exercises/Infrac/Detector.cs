using Standards;
using System;

namespace Infrac
{
    public class Detector
    {
        private IDetectable[] devices = new IDetectable[5];

        public void Connect(IDetectable device)
        {
            for(int i = 0; i < devices.Length; i++)
            {
                if (devices[i] == null)
                {
                    devices[i] = device;
                    return;
                }
            }
        }

        public void Detect()
        {
            Console.WriteLine("Hmmmm, something's wrong");
            foreach(IDetectable device in devices)
            {
                device?.Detect();
            }
        }
    }
}
