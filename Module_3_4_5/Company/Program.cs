using System;

namespace Company
{
    class Program
    {
        static void Main(string[] args)
        {
            // Big bang
            Michel michel = new Michel();
            Marco marco = new Marco();
            Robocop robo = new Robocop();
            Arvin arvin = new Arvin();

            ACME acme = new ACME();

            // Here we see that Michel and ACME starts to interact!!!
            acme.werknemer = michel;

            acme.Start();

        }
    }
}
