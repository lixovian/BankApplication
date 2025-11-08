using ViewManagerLibrary.Exceptions;

namespace ViewManagerLibrary.ViewManager
{
    /// <summary>
    /// Менеджер окон
    /// </summary>
    public class ViewManager : IViewManager
    {
        private readonly Dictionary<string, View> _views = [];
    
        private string _currentView = "";
        private bool _isInterrupted;
        private bool _managerWorks;

        private object[] _args = [];
        
        public void AddView(string id, View view)
        {
            _views[id] = view;
        }
        
        public void ChangeView(string id, params object[]? args)
        {
            if (!_views.ContainsKey(id))
            {
                throw new InvalidViewException();
            }

            _currentView = id;
            _isInterrupted = true;
            _args = args ?? [];
        }

        public View GetCurrent()
        {
            return _views[_currentView];
        }

        public void StartManager()
        {
            if (_managerWorks)
            {
                return;
            }

            _managerWorks = true;
            
            // Цикл бесконечного повтора решения
            while (_managerWorks)
            {
                View currentView = GetCurrent();

                Console.Clear();

                currentView.OnStart(_args);

                _isInterrupted = false;
                while (!_isInterrupted)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    Console.Clear();
                    currentView.OnIteration(key);
                }

                currentView.OnClose();
            }
        }

        public void EndManager()
        {
            _managerWorks = false;
            _isInterrupted = true;
        }
    }
}