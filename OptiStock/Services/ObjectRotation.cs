using Evergine.Components.Fonts;
using Evergine.Framework;
using Evergine.Framework.Graphics;
using Evergine.Framework.Services;
using System;
using System.Linq;

namespace OptiStock.Services
{
    public class ObjectRotation : Service
    {
        Entity camera;
        Entity entity;
        Text3DMesh textMesh;

        int timePassed = 0;

        ScreenContextManager screenContextManager;
        public String defaultTagToFollow = "base";

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
                entity = scene.Managers.EntityManager.FindAllByTag(defaultTagToFollow).First();
                camera = scene.Managers.EntityManager.FindAllByTag("camera").First();
                textMesh = scene.Managers.EntityManager.FindAllByTag("text").First().FindComponent<Text3DMesh>();
            };
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
            switch (this.objectToFollow)
            {
                case ChangeObjectToFollow.baseObject:
                    textMesh.Text = "Base";
                    break;
                case ChangeObjectToFollow.Cube:
                    textMesh.Text = "Cube";
                    break;
            }
        }
    }
}
