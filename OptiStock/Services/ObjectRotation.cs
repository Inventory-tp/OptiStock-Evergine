using Evergine.Components.Fonts;
using Evergine.Framework;
using Evergine.Framework.Graphics;
using Evergine.Framework.Services;
using System;
using System.Diagnostics;
using System.Linq;
using System.Timers;

namespace OptiStock.Services
{
    public class ObjectRotation : Service
    {
        Entity camera;
        Entity entity;
        Text3DMesh textMesh;

        private Scene scene;

        int timePassed = 0;

        ScreenContextManager screenContextManager;
        public String defaultTagToFollow = "Base";

        public enum ChangeObjectToFollow
        {
            baseObject,
            Cube
        }

        private ChangeObjectToFollow objectToFollow;

        public ChangeObjectToFollow ObjectToFollow
        {
            get => objectToFollow;
            set
            {
                this.objectToFollow = value;
                this.changeObjectToFollow();
            }
        }
        
        protected override void Start()
        {
            base.Start();

            screenContextManager = Application.Current.Container.Resolve<ScreenContextManager>();
            screenContextManager.OnActivatingScene += (scene) =>
            {
                this.scene = scene;
                entity = scene.Managers.EntityManager.FindAllByTag(defaultTagToFollow).First();
                camera = scene.Managers.EntityManager.FindAllByTag("camera").First();
                textMesh = scene.Managers.EntityManager.FindAllByTag("text").First().FindComponent<Text3DMesh>();
            };

            // Boucle de rotation
            System.Timers.Timer timer = new System.Timers.Timer(1000 / 60);
            timer.Elapsed += (sender, e) => MyLoopMethod();
            timer.Start();
        }

        protected void MyLoopMethod()
        {
            timePassed++;

            if (entity == null || camera == null) return;

            Transform3D entityTransform = entity.FindComponent<Transform3D>();
            Transform3D cameraTransform = camera.FindComponent<Transform3D>();

            float radius = 10.0f; // Rayon de la rotation
            float angleSpeed = 0.01f; // Vitesse de rotation

            float angle = (float)timePassed * angleSpeed;
            float cameraX = entityTransform.Position.X + radius * (float)Math.Cos(angle);
            float cameraZ = entityTransform.Position.Z + radius * (float)Math.Sin(angle);

            float objectY = entityTransform.Position.Y + 10;

            cameraTransform.SetLocalTransform(new Evergine.Mathematics.Vector3(cameraX, objectY, cameraZ), cameraTransform.LocalOrientation, cameraTransform.LocalScale);

            // Faire en sorte que la caméra regarde l'objet
            cameraTransform.LookAt(entityTransform.Position);
        }

        public void changeObjectToFollow()
        {
            String tag = entity.Tag;
            if (tag == "Base")
            {
                entity = scene.Managers.EntityManager.FindAllByTag("Cube").First();
                textMesh.Text = "Cube";
            }
            else
            {
                entity = scene.Managers.EntityManager.FindAllByTag("Base").First();
                textMesh.Text = "Base";
            }
        }
    }
}
