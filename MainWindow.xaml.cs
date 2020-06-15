using HelixToolkit.Wpf.SharpDX;
using HelixToolkit.Wpf.SharpDX.Animations;
using HelixToolkit.Wpf.SharpDX.Assimp;
using HelixToolkit.Wpf.SharpDX.Controls;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Real_3D_Model_Viewer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Property_Changes
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName]string info = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        protected bool SetValue<T>(ref T backingField, T value, [CallerMemberName]string propertyName = "")
        {
            if (Equals(backingField, value))
            {
                return false;
            }

            backingField = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        #endregion
        public EffectsManager EffectsManager { get; }
        public Camera Camera { get; }
        public MainWindow()//инициализация главного окна
        {

            InitializeComponent();
            EffectsManager = new DefaultEffectsManager();
            Camera = new OrthographicCamera()
            {
                LookDirection = new System.Windows.Media.Media3D.Vector3D(0, -10, -10),
                Position = new System.Windows.Media.Media3D.Point3D(0, 10, 10),
                UpDirection = new System.Windows.Media.Media3D.Vector3D(0, 1, 0),
                FarPlaneDistance = 5000,
                NearPlaneDistance = 0.1f
            };
            DataContext = this;
        }
        private void OpenModel_Button_Click(object sender, RoutedEventArgs e)
        {
            ImportTry();
        }
        private void ClearScene_Button_Click(object sender, RoutedEventArgs e)
        {
            Animations.Clear();
            GroupModel.Clear();
            MessageBox.Show("Сцена была очищена.");
        }
        public HelixToolkitScene scene;
        public ObservableCollection<Animation> Animations { get; } = new ObservableCollection<Animation>();
        public SceneNodeGroupModel3D GroupModel { get; } = new SceneNodeGroupModel3D();
        public void ImportTry()
        {
            var opFile = new OpenFileDialog();
            if (opFile.ShowDialog() == true)
            {
                try
                {
                    var path = opFile.FileName;
                    var loader = new Importer();
                    var scene = loader.Load(path);
                    if (scene != null)
                    {
                        GroupModel.AddNode(scene.Root);
                    }
                    if (scene.HasAnimation)
                    {
                        foreach (var ani in scene.Animations)
                        {
                            Animations.Add(ani);
                        }
                    }
                    MessageBox.Show("Модель была успешно добавлена на сцену.");
                }
                catch
                {
                    MessageBox.Show("Ошибка во время загрузки модели.");
                }
            }

        }
        public bool enableAnimation = false;
        public bool EnableAnimation
        {
            set
            {
                if (SetValue(ref enableAnimation, value))
                {
                    if (value)
                    {
                        StartAnimation();
                    }
                    else
                    {
                        StopAnimation();
                    }
                }
            }
            get { return enableAnimation; }
        }
        public NodeAnimationUpdater animationUpdater;
        public Animation selectedAnimation = null;
        public Animation SelectedAnimation
        {
            set
            {
                if (SetValue(ref selectedAnimation, value))
                {
                    StopAnimation();
                    if (value != null)
                    {
                        animationUpdater = new NodeAnimationUpdater(value);
                    }
                    else
                    {
                        animationUpdater = null;
                    }
                    if (enableAnimation)
                    {
                        StartAnimation();
                    }
                }
            }
            get
            {
                return selectedAnimation;
            }
        }
        private CompositionTargetEx compositeHelper = new CompositionTargetEx();
        public void StartAnimation()
        {
            compositeHelper.Rendering += CompositeHelper_Rendering;
        }
        public void StopAnimation()
        {
            compositeHelper.Rendering -= CompositeHelper_Rendering;
        }

        private void CompositeHelper_Rendering(object sender, System.Windows.Media.RenderingEventArgs e)
        {
            if (animationUpdater != null)
            {
                animationUpdater.Update(Stopwatch.GetTimestamp(), Stopwatch.Frequency);
            }
        }
        private void QuestButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Горячие клавиши:\n" +
                "1)B, F, T, D, L, R - просмотр сцены с разных сторон (Back, Front, Top, Bottom, Left, Right соответственно).\n" +
                "2) Прокрутка колесика мышки для масштабирования.\n" +
                "3) Правая кнопка для вращения сцены/модели.\n" +
                "4) Левая кнопка для перемещения модели по сцене." +
                "\n Для активации выбрать анимацию из списка.");
        }
    }
}