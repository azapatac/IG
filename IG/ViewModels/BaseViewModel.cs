namespace IG
{
    using Prism.AppModel;
    using Prism.Mvvm;

    public class BaseViewModel : BindableBase, IPageLifecycleAware
    {
        public virtual void OnAppearing() { }

        public virtual void OnDisappearing() { }
    }
}