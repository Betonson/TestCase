using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestCase
{
    public class FieldOfView_Mesh : MonoBehaviour
    {
        private Mesh _mesh;
        private float _fovAngle = 90.0f;
        private Vector3 _origin;
        private int _rayCount = 50;
        private float _angle = 0.0f;
        private float _viewDistance = 5.0f;
        //private float _angleIncrease = _fovAngle / _rayCount;
        void Start()
        {
            float _angleIncrease = _fovAngle / _rayCount;
            _mesh = new Mesh();
            GetComponent<MeshFilter>().mesh = _mesh;
        }


        void Update()
        {
            _origin = transform.position;
            float angleIncrease = _fovAngle / _rayCount;
            Vector3[] vertices = new Vector3[_rayCount + 2];
            Vector2[] uv = new Vector2[vertices.Length];
            int[] triangles = new int[_rayCount * 3];

            vertices[0] = _origin;

            int vertexIndex = 1;
            int triangleIndex = 0;
            for (int i = 0; i <= _rayCount; i++)
            {
                Vector3 vertex;
                Ray ray = new Ray(_origin, GetVectorFromAngle(_angle));
                //RaycastHit raycastHit;
                if (Physics.Raycast(ray, out RaycastHit raycastHit, _viewDistance))
                {
                    vertex = raycastHit.point;
                    Debug.DrawLine(_origin, raycastHit.collider.transform.position, Color.green, 0, false);
                }
                else
                {
                    vertex = _origin + GetVectorFromAngle(_angle) * _viewDistance;
                }
                vertices[vertexIndex] = vertex;

                if (i > 0)
                {
                    triangles[triangleIndex + 0] = 0;
                    triangles[triangleIndex + 1] = vertexIndex - 1;
                    triangles[triangleIndex + 2] = vertexIndex;

                    triangleIndex += 3;
                }
                vertexIndex++;
                _angle -= angleIncrease;
            }

            _mesh.vertices = vertices;
            _mesh.uv = uv;
            _mesh.triangles = triangles;
            Debug.Log("MeshDone! " + _mesh.vertices.Length);
        }

        private Vector3 GetVectorFromAngle(float angle)
        {
            float angleRad = angle * (Mathf.PI / 180.0f);
            return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
        }
    }
}
