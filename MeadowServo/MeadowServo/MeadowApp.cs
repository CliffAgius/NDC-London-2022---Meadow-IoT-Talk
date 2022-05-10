using Meadow;
using Meadow.Devices;
using Meadow.Foundation;
using Meadow.Foundation.Leds;
using Meadow.Foundation.Sensors.Buttons;
using Meadow.Foundation.Servos;
using Meadow.Units;
using System;
using System.Threading;

using AU = Meadow.Units.Angle.UnitType;

namespace MeadowServo
{
    // Change F7MicroV2 to F7Micro for V1.x boards
    public class MeadowApp : App<F7Micro, MeadowApp>
    {
        RgbPwmLed onboardLed;

        Servo servo1;
        Servo servo2;
        Servo servo3;

        PushButton button1;
        PushButton button2;
        PushButton button3;

        public MeadowApp()
        {
            Initialize();
        }

        void Initialize()
        {
            Console.WriteLine("Initialize hardware...");

            onboardLed = new RgbPwmLed(device: Device,
                redPwmPin: Device.Pins.OnboardLedRed,
                greenPwmPin: Device.Pins.OnboardLedGreen,
                bluePwmPin: Device.Pins.OnboardLedBlue,
                3.3f, 3.3f, 3.3f,
                Meadow.Peripherals.Leds.IRgbLed.CommonType.CommonAnode);

            onboardLed.SetColor(Color.Red);

            servo1 = new Servo(Device.CreatePwmPort(Device.Pins.D10), NamedServoConfigs.SG90);
            servo1.RotateTo(NamedServoConfigs.SG90.MinimumAngle);

            servo2 = new Servo(Device.CreatePwmPort(Device.Pins.D11), NamedServoConfigs.SG90);
            servo2.RotateTo(NamedServoConfigs.SG90.MinimumAngle);

            servo3 = new Servo(Device.CreatePwmPort(Device.Pins.D12), NamedServoConfigs.SG90);
            servo3.RotateTo(NamedServoConfigs.SG90.MinimumAngle);

            button1 = new PushButton(Device, Device.Pins.D03);
            button1.Clicked += Button1Clicked;

            button2 = new PushButton(Device, Device.Pins.D02);
            button2.Clicked += Button2Clicked;

            button3 = new PushButton(Device, Device.Pins.D01);
            button3.Clicked += Button3Clicked;

            onboardLed.SetColor(Color.Green);
        }

        void Button1Clicked(object sender, EventArgs e)
        {
            Console.WriteLine("Button pushed moving servo...");
            servo1.RotateTo(new Angle(90, AU.Degrees));
            Thread.Sleep(1000);
            servo1.RotateTo(new Angle(0, AU.Degrees));
        }

        void Button2Clicked(object sender, EventArgs e)
        {
            Console.WriteLine("Button pushed moving servo...");
            servo2.RotateTo(new Angle(90, AU.Degrees));
            Thread.Sleep(1000);
            servo2.RotateTo(new Angle(0, AU.Degrees));
        }

        void Button3Clicked(object sender, EventArgs e)
        {
            Console.WriteLine("Button pushed moving servo...");
            servo3.RotateTo(new Angle(90, AU.Degrees));
            Thread.Sleep(1000);
            servo3.RotateTo(new Angle(0, AU.Degrees));
        }
    }
}
