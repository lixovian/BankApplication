namespace ViewManagerLibrary.ViewManager
{
    public interface IViewManager
    {
        /// <summary>
        /// Добавить 
        /// </summary>
        /// <param name="id">Уникальный id, который ассоциируется с этим объектом</param>
        /// <param name="view">Объекта окна, который требуется добавить в менеджер</param>
        public void AddView(string id, View view);

        /// <summary>
        /// Поменять активное окно
        /// </summary>
        /// <param name="id">уникальный id окна, которое требуется выбрать активным</param>
        /// <param name="args">аргументы нужные для запуска нового окна</param>
        public void ChangeView(string id, params object[]? args);

        /// <summary>
        /// Получить текущее активное окно
        /// </summary>
        /// <returns>Текущее активное окно</returns>
        public View GetCurrent();

        /// <summary>
        /// Начать работу менеджера окон
        /// </summary>
        public void StartManager();
        
        /// <summary>
        /// Закончить работу менеджера окон
        /// </summary>
        public void EndManager();
    }
}