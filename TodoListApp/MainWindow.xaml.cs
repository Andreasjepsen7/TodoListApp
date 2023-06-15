using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace TodoListApp
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<TodoItem> todoItems;

        public MainWindow()
        {
            InitializeComponent();

            todoItems = new ObservableCollection<TodoItem>
            {
            };

            todoListBox.ItemsSource = todoItems;
        }

        private void AddTodo_Click(object sender, RoutedEventArgs e)
        {
            string newTodoText = newTodoTextBox.Text;

            if (!string.IsNullOrEmpty(newTodoText))
            {
                todoItems.Add(new TodoItem { Title = newTodoText, IsCompleted = false });
                newTodoTextBox.Clear();
            }
        }

        private void RemoveTodo_Click(object sender, RoutedEventArgs e)
        {
            if (todoListBox.SelectedItem != null)
            {
                todoItems.Remove((TodoItem)todoListBox.SelectedItem);
            }
        }
    }

    public class TodoItem : INotifyPropertyChanged
    {
        private string title;
        private bool isCompleted;

        public string Title
        {
            get { return title; }
            set
            {
                if (title != value)
                {
                    title = value;
                    OnPropertyChanged("Title");
                }
            }
        }

        public bool IsCompleted
        {
            get { return isCompleted; }
            set
            {
                if (isCompleted != value)
                {
                    isCompleted = value;
                    OnPropertyChanged("IsCompleted");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
