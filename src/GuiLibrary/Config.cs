namespace GuiLibrary
{
    /// <summary>
    /// Конфиг отображения элементов Gui
    /// </summary>
    public static class Config
    {
        public const ConsoleColor DefaultSelectedBackgroundColor = ConsoleColor.DarkYellow;
        public const ConsoleColor DefaultSelectedForegroundColor = ConsoleColor.Black;
        
        public const ConsoleColor DefaultInputBackgroundColor = ConsoleColor.DarkBlue;
        public const ConsoleColor DefaultInputForegroundColor = ConsoleColor.Cyan;
        
        public const ConsoleColor DefaultWrongBackgroundColor = ConsoleColor.DarkRed;
        public const ConsoleColor DefaultWrongForegroundColor = ConsoleColor.White;
        
        public const ConsoleColor DefaultRightBackgroundColor = ConsoleColor.DarkGreen;
        public const ConsoleColor DefaultRightForegroundColor = ConsoleColor.White;

        public const ConsoleColor DefaultButtonBackgroundColor = ConsoleColor.DarkGray;
        public const ConsoleColor DefaultButtonForegroundColor = ConsoleColor.White;

        public const int DefaultInputLength = 48;

        public const string DefaultTitleSeparator = ": ";
        public const string DefaultHorizontalBlockSeparator = " ";
        
        public const string DefaultCheckMark = "+";
        public const string DefaultCrossMark = "-";
        
        public const char DefaultInputFiller = '\u2591';
    }
}