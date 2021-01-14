using System;
using System.Collections.Generic;

namespace crossedWiresTask
{
    class Program
    {

        static void Main(string[] args)
        {
            string[] wire1 = {"R98","U47","R26","D63","R33","U87","L62","D20","R33","U53","R51"};
            string[] wire2 = {"U98","R91","D20","R16","D67","R40","U7","R15","U6","R7"};

            string[] wire3 = {"R75","D30","R83","U83","L12","D49","R71","U7","L72"};
            string[] wire4 = {"U62","R66","U55","R34","D71","R55","D58","R83"};

            int distance = calcClosestIntrDistance(wire1, wire2);
            Console.WriteLine("Distance {0}", distance);
        }

        static int calcClosestIntrDistance(string[] wire_1, string[] wire_2){
            int closest_distance = 0;
            List<string> trace_wire1 = new List<string>();
            List<string> trace_wire2 = new List<string>();

            Console.WriteLine("[" + String.Join(", ", wire_1) + "]");
            Console.WriteLine("[" + String.Join(", ", wire_2) + "]");

            trace_wire1 = traceWire(wire_1);
            trace_wire2 = traceWire(wire_2);

            // Check for coordinate intersections
            foreach(string coord_str in trace_wire1){
                if (trace_wire2.Contains(coord_str)){
                    // Get x-value of the intersection
                    int intersec_x = Int32.Parse(coord_str.Split(",")[0]);
                    // Convert negative coordinates to positive 
                    intersec_x = Math.Abs(intersec_x);
                    // Get y-value of the intersection
                    int intersec_y = Int32.Parse(coord_str.Split(",")[1]);
                    // Convert negative coordinates to positive 
                    intersec_y = Math.Abs(intersec_y);
                    int distance = intersec_x + intersec_y;
                    if (distance < closest_distance || closest_distance == 0){
                        closest_distance = distance;
                    }
                }
            }
            return closest_distance;
        }

        static List<string> traceWire(string[] wire){
            List<string> trace = new List<string>();
            int x = 0; int y = 0;

            foreach(string move in wire){
                char dir = move[0];
                int mag = Int32.Parse(move.Substring(1));
                for(int i = 0; i < mag; i++){
                    switch(dir){
                        case 'U':
                            y++;
                            break;
                        case 'D':
                            y--;
                            break;
                        case 'L':
                            x--;
                            break;
                        case 'R':
                            x++;
                            break;
                        default:
                            Console.WriteLine("Invalid direction {0}", dir);
                            break;
                    }
                    trace.Add($"{x},{y}");
                }
            }
            return trace;
        }

    }
}
