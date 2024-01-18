using Rhino.Compute;
using System;
using System.Diagnostics;

namespace DemoAPI.Models
{
    public class Program
    {
        public static void Main()
        {
            ComputeServer.AuthToken = "http://localhost:8081";

            // Uses standard Rhino3dmIO methods locally to create a sphere.
            var sphere = new Rhino.Geometry.Sphere(Rhino.Geometry.Point3d.Origin, 12);
            var sphereAsBrep = sphere.ToBrep();

            // the following function calls compute.rhino3d.com to get access to something not
            // available in Rhino3dmIO. In this case send a Brep to Compute and get a Mesh back.
            var meshes = MeshCompute.CreateFromBrep(sphereAsBrep);

            // Use regular Rhino3dmIO local calls to count the vertices in the mesh.
            Debug.WriteLine($"Got {meshes.Length} meshes");
            for (int i = 0; i < meshes.Length; i++)
            {
                Debug.WriteLine($"  {i + 1} mesh has {meshes[i].Vertices.Count} vertices");
            }

        }

    }
}