using OptiStock.MAUI.Evergine;
using OptiStock.Services;
using System.Diagnostics;
using System.Windows.Input;

namespace OptiStock.MAUI.Models
{
    public class ObjectRotationModel
    {
        public ICommand ObjectCommand { get; set; }

        private EvergineView evergineView;

        public ObjectRotationModel(EvergineView evergineView)
        {
            this.evergineView = evergineView;
            objectRotation = this.evergineView.Application.Container.Resolve<ObjectRotation>();
            ObjectCommand = new Command<string>((tag) =>
            {
                switch(tag)
                {
                    case "BASE":
                        objectRotation.ObjectToFollow = ObjectRotation.ChangeObjectToFollow.BASE;
                        break;
                    case "ETA1":
                        objectRotation.ObjectToFollow = ObjectRotation.ChangeObjectToFollow.ETA1;
                        break;
                    case "ETA2":
                        objectRotation.ObjectToFollow = ObjectRotation.ChangeObjectToFollow.ETA2;
                        break;
                    case "ETA3":
                        objectRotation.ObjectToFollow = ObjectRotation.ChangeObjectToFollow.ETA3;
                        break;
                    case "ETA4":
                        objectRotation.ObjectToFollow = ObjectRotation.ChangeObjectToFollow.ETA4;
                        break;
                    case "ETA5":
                        objectRotation.ObjectToFollow = ObjectRotation.ChangeObjectToFollow.ETA5;
                        break;
                    case "ETA6":
                        objectRotation.ObjectToFollow = ObjectRotation.ChangeObjectToFollow.ETA6;
                        break;
                    case "ETA7":
                        objectRotation.ObjectToFollow = ObjectRotation.ChangeObjectToFollow.ETA7;
                        break;
                    case "ETA8":
                        objectRotation.ObjectToFollow = ObjectRotation.ChangeObjectToFollow.ETA8;
                        break;
                    case "TABLE":
                        objectRotation.ObjectToFollow = ObjectRotation.ChangeObjectToFollow.TABLE;
                        break;
                }
            });
        }
    }
}
