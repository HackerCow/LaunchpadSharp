using System;
using Midi;

namespace launchpad
{
	public class Launchpad
	{
		public delegate void ButtonPressedHandler(ButtonPressedEventArgs args);
		public delegate void ButtonReleasedHandler(ButtonReleasedEventArgs args);

		public event ButtonPressedHandler ButtonPressed;
		public event ButtonReleasedHandler ButtonReleased;

		private readonly OutputDevice outDev;
		private InputDevice inDev;

		public Launchpad(OutputDevice outDev, InputDevice inDev)
		{
			this.outDev = outDev;
			this.inDev = inDev;
			inDev.NoteOn += InDevOnNoteOn;
		}

		private void InDevOnNoteOn(NoteOnMessage msg)
		{
			if(msg.Velocity == 0)
				ButtonReleased?.Invoke(new ButtonReleasedEventArgs(PitchToButton(msg.Pitch)));
			else
				ButtonPressed?.Invoke(new ButtonPressedEventArgs(PitchToButton(msg.Pitch)));
		}

		#region Conversion Tables
		private static LaunchpadButton PitchToButton(Pitch pitch)
		{
			switch (pitch)
			{
				case Pitch.CNeg1: return new LaunchpadButton(0, 0);
				case Pitch.CSharpNeg1: return new LaunchpadButton(1, 0);
				case Pitch.DNeg1: return new LaunchpadButton(2, 0);
				case Pitch.DSharpNeg1: return new LaunchpadButton(3, 0);
				case Pitch.ENeg1: return new LaunchpadButton(4, 0);
				case Pitch.FNeg1: return new LaunchpadButton(5, 0);
				case Pitch.FSharpNeg1: return new LaunchpadButton(6, 0);
				case Pitch.GNeg1: return new LaunchpadButton(7, 0);
				case Pitch.GSharpNeg1: return new LaunchpadButton(8, 0);

				case Pitch.E0: return new LaunchpadButton(0, 1);
				case Pitch.F0: return new LaunchpadButton(1, 1);
				case Pitch.FSharp0: return new LaunchpadButton(2, 1);
				case Pitch.G0: return new LaunchpadButton(3, 1);
				case Pitch.GSharp0: return new LaunchpadButton(4, 1);
				case Pitch.A0: return new LaunchpadButton(5, 1);
				case Pitch.ASharp0: return new LaunchpadButton(6, 1);
				case Pitch.B0: return new LaunchpadButton(7, 1);
				case Pitch.C1: return new LaunchpadButton(8, 1);

				case Pitch.GSharp1: return new LaunchpadButton(0, 2);
				case Pitch.A1: return new LaunchpadButton(1, 2);
				case Pitch.ASharp1: return new LaunchpadButton(2, 2);
				case Pitch.B1: return new LaunchpadButton(3, 2);
				case Pitch.C2: return new LaunchpadButton(4, 2);
				case Pitch.CSharp2: return new LaunchpadButton(5, 2);
				case Pitch.D2: return new LaunchpadButton(6, 2);
				case Pitch.DSharp2: return new LaunchpadButton(7, 2);
				case Pitch.E2: return new LaunchpadButton(8, 2);

				case Pitch.C3: return new LaunchpadButton(0, 3);
				case Pitch.CSharp3: return new LaunchpadButton(1, 3);
				case Pitch.D3: return new LaunchpadButton(2, 3);
				case Pitch.DSharp3: return new LaunchpadButton(3, 3);
				case Pitch.E3: return new LaunchpadButton(4, 3);
				case Pitch.F3: return new LaunchpadButton(5, 3);
				case Pitch.FSharp3: return new LaunchpadButton(6, 3);
				case Pitch.G3: return new LaunchpadButton(7, 3);
				case Pitch.GSharp3: return new LaunchpadButton(8, 3);

				case Pitch.E4: return new LaunchpadButton(0, 4);
				case Pitch.F4: return new LaunchpadButton(1, 4);
				case Pitch.FSharp4: return new LaunchpadButton(2, 4);
				case Pitch.G4: return new LaunchpadButton(3, 4);
				case Pitch.GSharp4: return new LaunchpadButton(4, 4);
				case Pitch.A4: return new LaunchpadButton(5, 4);
				case Pitch.ASharp4: return new LaunchpadButton(6, 4);
				case Pitch.B4: return new LaunchpadButton(7, 4);
				case Pitch.C5: return new LaunchpadButton(8, 4);

				case Pitch.GSharp5: return new LaunchpadButton(0, 5);
				case Pitch.A5: return new LaunchpadButton(1, 5);
				case Pitch.ASharp5: return new LaunchpadButton(2, 5);
				case Pitch.B5: return new LaunchpadButton(3, 5);
				case Pitch.C6: return new LaunchpadButton(4, 5);
				case Pitch.CSharp6: return new LaunchpadButton(5, 5);
				case Pitch.D6: return new LaunchpadButton(6, 5);
				case Pitch.DSharp6: return new LaunchpadButton(7, 5);
				case Pitch.E6: return new LaunchpadButton(8, 5);

				case Pitch.C7: return new LaunchpadButton(0, 6);
				case Pitch.CSharp7: return new LaunchpadButton(1, 6);
				case Pitch.D7: return new LaunchpadButton(2, 6);
				case Pitch.DSharp7: return new LaunchpadButton(3, 6);
				case Pitch.E7: return new LaunchpadButton(4, 6);
				case Pitch.F7: return new LaunchpadButton(5, 6);
				case Pitch.FSharp7: return new LaunchpadButton(6, 6);
				case Pitch.G7: return new LaunchpadButton(7, 6);
				case Pitch.GSharp7: return new LaunchpadButton(8, 6);

				case Pitch.E8: return new LaunchpadButton(0, 7);
				case Pitch.F8: return new LaunchpadButton(1, 7);
				case Pitch.FSharp8: return new LaunchpadButton(2, 7);
				case Pitch.G8: return new LaunchpadButton(3, 7);
				case Pitch.GSharp8: return new LaunchpadButton(4, 7);
				case Pitch.A8: return new LaunchpadButton(5, 7);
				case Pitch.ASharp8: return new LaunchpadButton(6, 7);
				case Pitch.B8: return new LaunchpadButton(7, 7);
				case Pitch.C9: return new LaunchpadButton(8, 7);
			}

			throw new ArgumentException();
		}

		private static readonly Pitch[,] Coords = {
			{Pitch.CNeg1, Pitch.CSharpNeg1, Pitch.DNeg1, Pitch.DSharpNeg1, Pitch.ENeg1, Pitch.FNeg1, Pitch.FSharpNeg1, Pitch.GNeg1, Pitch.GSharpNeg1},
			{Pitch.E0, Pitch.F0, Pitch.FSharp0, Pitch.G0, Pitch.GSharp0, Pitch.A0, Pitch.ASharp0, Pitch.B0, Pitch.C1},
			{Pitch.GSharp1, Pitch.A1, Pitch.ASharp1, Pitch.B1, Pitch.C2, Pitch.CSharp2, Pitch.D2, Pitch.DSharp2, Pitch.E2},
			{Pitch.C3, Pitch.CSharp3, Pitch.D3, Pitch.DSharp3, Pitch.E3, Pitch.F3, Pitch.FSharp3, Pitch.G3, Pitch.GSharp3},
			{Pitch.E4, Pitch.F4, Pitch.FSharp4, Pitch.G4, Pitch.GSharp4, Pitch.A4, Pitch.ASharp4, Pitch.B4, Pitch.C5},
			{Pitch.GSharp5, Pitch.A5, Pitch.ASharp5, Pitch.B5, Pitch.C6, Pitch.CSharp6, Pitch.D6, Pitch.DSharp6, Pitch.E6},
			{Pitch.C7, Pitch.CSharp7, Pitch.D7, Pitch.DSharp7, Pitch.E7, Pitch.F7, Pitch.FSharp7, Pitch.G7, Pitch.GSharp7},
			{Pitch.E8, Pitch.F8, Pitch.FSharp8, Pitch.G8, Pitch.GSharp8, Pitch.A8, Pitch.ASharp8, Pitch.B8, Pitch.C9}
		};
#endregion

		public void ButtonOn(LaunchpadButton button, LaunchpadColor color)
		{
			ButtonOn(button.X, button.Y, color);
		}

		public void ButtonOn(int x, int y, LaunchpadColor color)
		{
			outDev.SendNoteOn(Channel.Channel1, Coords[y,x], (int)color);
		}
		
		public void ButtonOff(LaunchpadButton button)
		{
			ButtonOff(button.X, button.Y);
		}

		public void ButtonOff(int x, int y)
		{
			outDev.SendNoteOff(Channel.Channel1, Coords[y, x], 12);
		}
	}
}
