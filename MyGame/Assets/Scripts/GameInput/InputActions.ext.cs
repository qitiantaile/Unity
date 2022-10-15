namespace GameInput
{
    public partial class InputActions
    {
        private static InputActions m_instance;
        public static InputActions Instance
        {
            get
            {
                if(m_instance == null)
                {
                    m_instance = new InputActions();
                    m_instance.Enable();
                }
                return m_instance;
            }
            private set => m_instance = value;
        }
    }
}
