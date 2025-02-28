namespace Delegates
{

	class Button
	{
		public delegate void ClickHandler();
		public event ClickHandler Click; // Define an event

		public void Press()
		{
			Click?.Invoke(); // Trigger the event if any subscribers exist
		}
	}
}
