namespace launchpad
{
	public class ButtonReleasedEventArgs
	{
		public LaunchpadButton Button { get; }

		public ButtonReleasedEventArgs(LaunchpadButton button)
		{
			Button = button;
		}
	}
}