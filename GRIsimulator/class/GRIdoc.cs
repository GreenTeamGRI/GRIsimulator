using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.IO;

namespace GRIsimulator {
    public class GRIdoc {

        //reporting tree
        String name { get; }
        String description { get; }
        GRInode root;
        //ownership
        String owner, company, type, auth;

        //new
        public GRIdoc(String nam, String des) {
            name = nam;
            description = des;
            //creates root
            root = new GRInode(this, new GRInode[0]);
        }

        //load
        public GRIdoc(String nam, String des, FileStream f) {
            name = nam;
            description = des;
            //creates root
            root = loadGRItree(f);
        }

        //populate tree
        private GRInode loadGRItree(FileStream f) {




            return new GRInode(this, new GRInode[0]);
        }

        //each node on the GRI tree, 
        //aka each TreeViewItem
        private class GRInode {
            String heading;
            String description;
            String[][] data;
            GRInode[] children;

            //root constructor
            public GRInode(GRIdoc doc, GRInode[] chi) {
                heading = doc.name;
                description = doc.description;
                children = chi;
            }

            //node constructor
            public GRInode(String hea, String des, GRInode[] chi) {
                heading = hea;
                description = des;
                children = chi;
            }

            //leaf constructor
            public GRInode(String hea, String des, String[][] dat) {
                heading = hea;
                description = des;
                data = dat;

            }
        }
    }
}
