using OptiStock.MAUI.Evergine;
using OptiStock.Services;
using System.Windows.Input;

namespace OptiStock.MAUI.Models
{
    public class ObjectRotationModel
    {
        public ICommand ObjectCommand { get; set; }

        private EvergineView evergineView;
        private ObjectRotation objectRotation;

        public ObjectRotationModel(EvergineView evergineView)
        {
            this.evergineView = evergineView;
            objectRotation = this.evergineView.Application.Container.Resolve<ObjectRotation>();
            ObjectCommand = new Command<string>((tag) =>
            {
                objectRotation.ObjectToFollow = ObjectRotation.ChangeObjectToFollow.Cube;
            });
        }
    }
}
