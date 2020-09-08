using Standards;
using System;

namespace Infrac
{
    public class Detector
    {
        private IDetectable[] devices = new IDetectable[5];
        private DeviceAction[] devices2 = new DeviceAction[5];

        // And this is what we call an event.
        //public event DeviceAction Actions;
        public event Action Actions;
        //private DeviceAction actions;
        //public event DeviceAction Actions
        //{
        //    add
        //    {
        //        actions += value;
        //    }
        //    remove
        //    {
        //        actions -= value;
        //    }
        //}

        public void Connect(DeviceAction action)
        {
            for (int i = 0; i < devices2.Length; i++)
            {
                if (devices2[i] == null)
                {
                    devices2[i] = action;
                    return;
                }
            }
        }
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
            //foreach(IDetectable device in devices)
            //{
            //    device?.Detect();
            //}
            //foreach(DeviceAction act in devices2)
            //{
            //    if (act != null) act();
            //    // Or
            //    //act?.Invoke();
            //}
            Actions?.Invoke();
        }
    }
}
