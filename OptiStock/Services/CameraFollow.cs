using Evergine.Framework;
using Evergine.Framework.Graphics;
using Evergine.Framework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OptiStock.Services
{
    public class CameraFollow : Behavior
    {
        Entity entityToFollow;
        Entity cameraEntity;

        ScreenContextManager screenContextManager;
        public String defaultTagToFollow = "base";
        protected override void Start()
        {
            base.Start();

            screenContextManager = Application.Current.Container.Resolve<ScreenContextManager>();
            screenContextManager.OnActivatingScene += (scene) =>
            {
                entityToFollow = scene.Managers.EntityManager.FindAllByTag(defaultTagToFollow).First();
                cameraEntity = scene.Managers.EntityManager.FindAllByTag("camera").First();
            };
        }

        protected override void Update(TimeSpan gameTime)
        {
            if (entityToFollow == null || cameraEntity == null) return;

            Transform3D entityTransform = entityToFollow.FindComponent<Transform3D>();
            Transform3D cameraTransform = cameraEntity.FindComponent<Transform3D>();

            float radius = 10.0f; // Rayon de la rotation
            float angleSpeed = 0.01f; // Vitesse de rotation

            // Calculer la position de la caméra en fonction de l'angle
            float angle = (float)gameTime.TotalSeconds * angleSpeed;
            float cameraX = entityTransform.Position.X + radius * (float)Math.Cos(angle);
            float cameraZ = entityTransform.Position.Z + radius * (float)Math.Sin(angle);

            float objectY = entityTransform.Position.Y + 10;

            cameraTransform.SetLocalTransform(new Evergine.Mathematics.Vector3(cameraX, objectY, cameraZ), cameraTransform.LocalOrientation, cameraTransform.LocalScale);
        }
    }
}
