using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Evergine.Framework;
using Evergine.Framework.Graphics;
using Evergine.Mathematics;

namespace OptiStock.Services
{
    internal class CameraFollow : Behavior
    {
        public string CameraTag { get; set; } = "camera";
        public string CubeTag { get; set; } = "cube";

        private Transform3D cameraTransform;
        private Transform3D cubeTransform;

        protected override void OnActivated()
        {
            base.OnActivated();

            var cameraEntity = this.Managers.EntityManager.FindAllByTag(CameraTag).FirstOrDefault();
            var cubeEntity = this.Managers.EntityManager.FindAllByTag(CubeTag).FirstOrDefault();

            cubeTransform = cubeEntity.FindComponent<Transform3D>();
        }

        protected override void Update(TimeSpan gameTime)
        {
            float rotationAngle = 0.0001f;

            // Rotation autour de l'axe X
            Quaternion rotationX = Quaternion.CreateFromAxisAngle(Vector3.UnitX, rotationAngle * 10);

            // Rotation autour de l'axe Y
            Quaternion rotationY = Quaternion.CreateFromAxisAngle(Vector3.UnitY, rotationAngle * 5);

            // Rotation autour de l'axe Z
            Quaternion rotationZ = Quaternion.CreateFromAxisAngle(Vector3.UnitZ, rotationAngle * 2);

            // Combinaison des rotations pour tous les axes
            Quaternion totalRotation = Quaternion.Concatenate(rotationX, rotationY);
            totalRotation = Quaternion.Concatenate(totalRotation, rotationZ);

            // Appliquer la rotation totale à cubeTransform
            cubeTransform.Orientation *= totalRotation;
        }
    }
}
