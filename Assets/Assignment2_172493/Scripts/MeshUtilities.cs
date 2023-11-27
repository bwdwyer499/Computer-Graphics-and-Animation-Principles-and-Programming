using System.Collections;
using UnityEngine;

namespace KIT307_172493
{
    public class MeshUtilities
    {

        public static Mesh Pyramid(float size)
        {
            Mesh mesh = new Mesh();

            //create vectors for the 4 triangle sides (4*3) and for the bottom (4)
            Vector3[] vertices = new Vector3[4 * 3 + 4]
           {
            //front P face  
		    new Vector3(size,0,size),       // Point 1     
            new Vector3(0, size, 0),        // Point 2
            new Vector3(size, 0, -size),    // Point 3    
                                                
            // back P face                      
            new Vector3(size, 0, -size),    // Point 4
            new Vector3(0, size, 0),        // Point 5
            new Vector3(-size, 0, -size),   // Point 6  
                                                
            // left P face                      
            new Vector3(-size, 0, -size),   // Point 7
            new Vector3(0, size, 0),        // Point 8
            new Vector3(-size, 0, size),    // Point 9      
                                                
            // right P face                     
            new Vector3(-size, 0, size),    // Point 10
            new Vector3(0, size, 0),        // Point 11
            new Vector3(size, 0, size),     // Point 12    
                                                
            // bottom P face                    
            new Vector3(size,0 , size),     // Point 13
            new Vector3(size,0 , -size),    // Point 14
            new Vector3(-size, 0 , -size),  // Point 15
            new Vector3(-size, 0 , size),   // Point 16

           };
            mesh.vertices = vertices;

            Vector2[] uvs = new Vector2[4 * 3 + 4] //24
          {
                //these points corispond to points on a cube that a texture will be apllied to.
            //front
		    new Vector2(0.34f,0.33f),       //
            new Vector2(0.5f,0.05f),        // top
            new Vector2(0.66f,0.33f),       //        
                                        
            // left  2                   
            new Vector2(0.34f,0.67f),       //Point 
            new Vector2(0.5f,0.94f),        //Point top
            new Vector2(0.66f, 0.67f),      //Point             
                                        
            // back  2                    
            new Vector2(0.33f,0.34f),       //Point 
            new Vector2(0.05f,0.5f),        //Point top
            new Vector2(0.33f,0.66f),       //Point            
                                        
            // right  2                    
            new Vector2(0.67f,0.34f),       //Point 
            new Vector2(0.94f,0.5f),        //Point top
            new Vector2(0.67f, 0.66f),      //Point 
                                                    
            // bottom 2                    
            new Vector2(0.34f, 0.34f),      //Point 
            new Vector2(0.66f,0.34f),       //Point 
            new Vector2(0.66f, 0.66f),      //Point 
            new Vector2(0.34f,0.66f),       //Point 
                                          
             
          };
            mesh.uv = uvs;

            int[] tris = new int[6 * 3] // int [18]
            {
            //front
            0, 2, 1,
            

            // back
            3,5,4,
            

            // left
            6,8,7,
            

            // right
            9,11,10,
            

            // bottom
            15,13,12,
            13,15,14,

            };
            mesh.triangles = tris;
            mesh.RecalculateNormals();
            return mesh;
        }
        public static Mesh Cube(float size)
        {
            Mesh mesh = new Mesh();

            Vector3[] vertices = new Vector3[4 * 6] //24
            {
            //front
		    new Vector3(-size,-size,-size),     //Point 
            new Vector3(size, -size, -size),    //Point 
            new Vector3(size, size, -size),     //Point 
            new Vector3(-size, size, -size),    //Point 
                                                
            // back                             
            new Vector3(-size, -size, size),    //Point 
            new Vector3(size, -size, size),     //Point 
            new Vector3(size, size, size),      //Point 
            new Vector3(-size, size, size),     //Point 
                                                 
            // left                              
            new Vector3(-size, -size, -size),   //Point 
            new Vector3(-size, size, -size),    //Point 
            new Vector3(-size, size, size),     //Point 
            new Vector3(-size, -size, size),    //Point 
                                                 
            // right                             
            new Vector3(size, -size, -size),    //Point 
            new Vector3(size, size, -size),     //Point 
            new Vector3(size, size, size),      //Point 
            new Vector3(size, -size, size),     //Point 
                                                 
            // bottom                            
            new Vector3(-size, -size, -size),   //Point 
            new Vector3(-size, -size, size),    //Point 
            new Vector3(size, -size, size),     //Point 
            new Vector3(size, -size, -size),    //Point 
                                                 
            // top                               
            new Vector3(-size, size, -size),    //Point 
            new Vector3(-size, size, size),     //Point 
            new Vector3(size, size, size),      //Point 
            new Vector3(size, size, -size)      //Point 
            };
            mesh.vertices = vertices;


            Vector2[] uvs = new Vector2[4 * 6] //24
            {
                //these points corispond to points on a cube that a texture will be apllied to.
            //front
		    new Vector2(0f,0f),         //bottom left Point of texture.
            new Vector2(0.5f, 0f),      //bottom right  Point of texture
            new Vector2(0.5f, 0.5f),    //top right Point of texture
            new Vector2(0f, 0.5f),      //top left Point of texture
                                        
            // back   2                   
            new Vector2(0.5f, 0.5f),    //Point 
            new Vector2(1f,0.5f),       //Point 
            new Vector2(1f,1f),         //Point 
            new Vector2(0.5f,1f),       //Point 
                                        
            // left   2                    
            new Vector2(0f, 0.5f),      //Point 
            new Vector2(0.5f, 0.5f),    //Point 
            new Vector2(0.5f,1f),       //Point 
            new Vector2(0f, 1f),        //Point 
                                        
            // right  2                    
            new Vector2(0.5f, 0f),      //Point 
            new Vector2(1f, 0f),        //Point 
            new Vector2(1f,0.5f),       //Point 
            new Vector2(0.5f, 0.5f),    //Point 
                                         
            // bottom 2                    
            new Vector2(0.5f, 0.5f),    //Point 
            new Vector2(1f,0.5f),       //Point 
            new Vector2(1f,1f),         //Point 
            new Vector2(0.5f,1f),       //Point 
                                          
            // top    2                    
            new Vector2(0.5f, 0.5f),    //Point 
            new Vector2(1f,0.5f),       //Point 
            new Vector2(1f,1f),         //Point 
            new Vector2(0.5f,1f),       //Point                
            };
            mesh.uv = uvs;

            int[] tris = new int[6 * 2 * 3] //36
           {
            //front
            3, 2, 1,
            3, 1, 0,

            // back
            4,5,6,
            4,6,7,

            // left
            11,10,9,
            11,9,8,

            // right
            12,13,14,
            12,14,15,

            // bottom
            19,18,17,
            19,17,16,

            // top
            20,21,22,
            20,22,23
           };
            mesh.triangles = tris;
            mesh.RecalculateNormals();

            return mesh;
        }

        public static Mesh Bolt(float length, float headRadius, float shaftRadius, float headDepth, int headSides, int shaftDensity)
        {
            Mesh mesh = new Mesh();

            Vector3[] vertices = new Vector3[(4 * shaftDensity) + (4 * headSides) + 4]; // need top and bottom vertices [(4 * shaftDensity) + (4 * headSides) + 2]
            
            float dTheta = Mathf.PI * 2.0f / shaftDensity;
            float dTheta2 = Mathf.PI * 2.0f / headSides;

            int topsidestart = 0;
            int botsidestart = shaftDensity;
            int topcapstart = 2 * shaftDensity;
            int botcapstart = 3 * shaftDensity;
            int centrestart = 4 * shaftDensity;

            int boltTopSideStart = centrestart + 2;
            int boltBotSideStart = 5 * headSides;
            int boltTopCapStart = 6 * headSides;
            int boltBotCapStart = 7 * headSides;
            int boltCentreStart = 8 * headSides;

            for (int i = 0; i < shaftDensity; i++)
            {
                //Bolt Shaft
                float theta = i * dTheta;
                float x = shaftRadius * Mathf.Cos(theta);
                float z = shaftRadius * Mathf.Sin(theta);

                // top vertex
                vertices[i + topsidestart] = new Vector4(x, length, z);

                // bottom vertex
                vertices[i + botsidestart] = new Vector4(x, -length, z);

                // top cap 
                vertices[i + topcapstart] = new Vector4(x, length, z);

                // bottom cap 
                vertices[i + botcapstart] = new Vector4(x, -length, z);
            }
            for (int j = 0; j < headSides; j++)
            {
                //bolt Head
                float theta2 = j * dTheta2;
                float x2 = headRadius * Mathf.Cos(theta2);
                float z2 = headRadius * Mathf.Sin(theta2);
                //head top vertex
                vertices[j + boltTopSideStart] = new Vector4(x2, length + headDepth, z2);
                //head bottom vertex
                vertices[j + boltBotSideStart] = new Vector4(x2, length, z2);
                //head top cap
                vertices[j + boltTopCapStart] = new Vector4(x2, length + headDepth, z2);
                //head bottom cap
                vertices[j + boltBotCapStart] = new Vector4(x2, length, z2);
            }

            vertices[centrestart] = new Vector4(0, length, 0);
            vertices[centrestart + 1] = new Vector4(0, -length, 0);

            vertices[boltCentreStart] = new Vector4(0, length + headDepth, 0);
            vertices[boltCentreStart + 1] = new Vector4(0, length, 0);

            mesh.vertices = vertices;

            int[] tris = new int[(shaftDensity * 6 + shaftDensity * 6) * (headSides * 6 + headSides * 6)]; // two tris for each side

            int pos = 0;

            for (int i = 0; i < shaftDensity; i++)
            {
                //bolt shaft main body
                tris[pos++] = topsidestart + i;                         // current top vertex
                tris[pos++] = topsidestart + (i + 1) % shaftDensity;    // next top vertex (wrapping)
                tris[pos++] = botsidestart + (i + 1) % shaftDensity;    // next bottom vertex (wrapping)

                tris[pos++] = topsidestart + i;                         // current top vertex
                tris[pos++] = botsidestart + (i + 1) % shaftDensity;    // next bottom vertex (wrapping)
                tris[pos++] = botsidestart + i;                         // current bottom vertex

                //bolt shaft top cap - Not needed for the 100% correct version
                tris[pos++] = topcapstart + i;                          // 
                tris[pos++] = centrestart;                              //
                tris[pos++] = topcapstart + (i + 1) % shaftDensity;     //              

                //bolt shaft bottom cap
                tris[pos++] = botcapstart + i;                          // 
                tris[pos++] = botcapstart + (i + 1) % shaftDensity;     // 
                tris[pos++] = centrestart + 1;                          //
            }
            for (int j = 0; j < headSides; j++)
            {

                //bolt head body
                tris[pos++] = boltTopSideStart + j;
                tris[pos++] = boltTopSideStart + (j + 1) % headSides;
                tris[pos++] = boltBotSideStart + (j + 1) % headSides;

                tris[pos++] = boltTopSideStart + j;
                tris[pos++] = boltBotSideStart + (j + 1) % headSides;
                tris[pos++] = boltBotSideStart + j;

                //top
                tris[pos++] = boltTopCapStart + j;
                tris[pos++] = boltCentreStart;
                tris[pos++] = boltTopCapStart + (j + 1) % headSides;

                //bottom
                tris[pos++] = boltBotCapStart + j;
                tris[pos++] = boltBotCapStart + (j + 1) % headSides;
                tris[pos++] = boltCentreStart + 1;

            }

            mesh.triangles = tris;

            mesh.RecalculateNormals();

            return mesh;

        }

        public static Mesh Cylinder(int d, float r, float h)
        {
            Mesh mesh = new Mesh();

            Vector3[] vertices = new Vector3[(4 * d) + 2];    // need top and bottom vertices
            //Vector3[] vertices = new Vector3[(4 * d) + 4];      // need top and bottom vertices
            //Vector2[] uvs = new Vector2[(4 * d) + 2];         // need top and bottom vertices

            float dTheta = Mathf.PI * 2.0f / d;

            int topsidestart = 0;
            int botsidestart = d;
            int topcapstart = 2 * d;
            int botcapstart = 3 * d;
            int centrestart = 4 * d ;

            for (int i = 0; i < d; i++)
            //for (int i = 0; i <= d; i++)
            {
                float theta = i * dTheta;
                float x = r * Mathf.Cos(theta);
                float z = r * Mathf.Sin(theta);

                // top vertex
                vertices[i + topsidestart] = new Vector4(x, h, z);

                // bottom vertex
                vertices[i + botsidestart] = new Vector4(x, -h, z);

                // top cap 
                vertices[i + topcapstart] = new Vector4(x, h, z);

                // bottom cap 
                vertices[i + botcapstart] = new Vector4(x, -h, z);
            }

            vertices[centrestart] = new Vector4(0, h, 0);
            vertices[centrestart + 1] = new Vector4(0, -h, 0);

            mesh.vertices = vertices;

            int[] tris = new int[d * 6 + d * 6]; // two tris for each side

            int pos = 0;

            for (int i = 0; i < d; i++)
            {
                tris[pos++] = topsidestart + i;                     // current top vertex
                tris[pos++] = topsidestart + (i + 1) % d;        // next top vertex (wrapping)
                tris[pos++] = botsidestart + (i + 1) % d;        // next bottom vertex (wrapping)

                tris[pos++] = topsidestart + i;                     // current top vertex
                tris[pos++] = botsidestart + (i + 1) % d;        // next bottom vertex (wrapping)
                tris[pos++] = botsidestart + i;                     // current bottom vertex

                tris[pos++] = topcapstart + i;                      // 
                tris[pos++] = centrestart;                          //
                tris[pos++] = topcapstart + (i + 1) % d;         // 

                tris[pos++] = botcapstart + i;                      // 
                tris[pos++] = botcapstart + (i + 1) % d;         // 
                tris[pos++] = centrestart + 1;                      // 
            }          

            mesh.triangles = tris;

            mesh.RecalculateNormals();

            return mesh;
        }


        public static Mesh Sweep(Vector3[] profile, Matrix4x4[] path, bool closed)
        {
            Mesh mesh = new Mesh();

            int numVerts = path.Length * profile.Length;
            int numTris;

            if (closed)
                numTris = 2 * path.Length * profile.Length;
            else
                numTris = 2 * (path.Length - 1) * profile.Length;


            Vector3[] vertices = new Vector3[numVerts];
            int[] tris = new int[numTris * 3];

            for (int i = 0; i < path.Length; i++)
            {
                for (int j = 0; j < profile.Length; j++)
                {
                    Vector3 v = path[i].MultiplyPoint(profile[j]);
                    vertices[i * profile.Length + j] = v;

                    if (closed || i < path.Length - 1)
                    {

                        tris[6 * (i * profile.Length + j)] = (j + i * profile.Length);
                        tris[6 * (i * profile.Length + j) + 1] = ((j + 1) % profile.Length + i * profile.Length);
                        tris[6 * (i * profile.Length + j) + 2] = ((j + 1) % profile.Length + ((i + 1) % path.Length) * profile.Length);
                        tris[6 * (i * profile.Length + j) + 3] = (j + i * profile.Length);
                        tris[6 * (i * profile.Length + j) + 4] = ((j + 1) % profile.Length + ((i + 1) % path.Length) * profile.Length);
                        tris[6 * (i * profile.Length + j) + 5] = (j + ((i + 1) % path.Length) * profile.Length);
                    }
                }
            }

            mesh.vertices = vertices;

            mesh.triangles = tris;

            mesh.RecalculateNormals();

            return mesh;
        }
        public static Matrix4x4[] MakeCirclePath(float radius, int density)
        {
            Matrix4x4[] path = new Matrix4x4[density];
            for (int i = 0; i < density; i++)
            {
                float angle = (360.0f * i) / density;
                path[i] = Matrix4x4.Rotate(Quaternion.Euler(0, -angle, 0)) * Matrix4x4.Translate(new Vector3(radius, 0, 0));
            }
            return path;
        }

        public static Vector3[] MakeCircleProfile(float radius, int density)
        {
            Vector3[] profile = new Vector3[density];
            for (int i = 0; i < density; i++)
            {
                float angle = (2.0f * Mathf.PI * i) / density;
                profile[i] = new Vector3(radius * Mathf.Cos(angle), radius * Mathf.Sin(angle), 0);
            }
            return profile;
        }

    }
}