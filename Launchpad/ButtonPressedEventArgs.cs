namespace launchpad
{
	public class ButtonPressedEventArgs
	{
		public LaunchpadButton Button { get; }

		public ButtonPressedEventArgs(LaunchpadButton button)
		{
			Button = button;
		}
	}
}