﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelData
{
    public class TableEntry
    {
        public uint index;
        public uint originalPointer; // DONT SAVE THIS
        public bool bHasData;  // DONT SAVE THIS
        public string name; // DONT SAVE THIS (??)
        public string filePath; // DONT SAVE THIS (??)
        public int size;

        public static StringBuilder nameSB;

        public virtual bool isAnmChrEdit { get; internal set; }

        public TableEntry()
        {
            name = "";
        }

        public virtual void GuessName()
        {
            switch(index)
            {
                case 0x0:
                    name = "Idle Stance";
                    break;
                case 0x1:
                    name = "Walk Forward";
                    break;
                case 0x2:
                    name = "Walk Backward";
                    break;
                case 0x3:
                    name = "Dash Forward";
                    break;
                case 0x4:
                    name = "Dash Backward";
                    break;
                case 0x5:
                    name = "Air Dash Forward";
                    break;
                case 0x6:
                    name = "Air Dash Backward";
                    break;
                case 0x9:
                    name = "Fall";
                    break;
                case 0xA:
                    name = "Crouch Enter";
                    break;
                case 0xC:
                    name = "Jump";
                    break;
                case 0xD:
                    name = "Jump Forward";
                    break;
                case 0xE:
                    name = "Jump Backward";
                    break;
                case 0xF:
                    name = "Midair Jump";
                    break;
                case 0x10:
                    name = "Midair Jump Forward";
                    break;
                case 0x11:
                    name = "Midair Jump Backward";
                    break;

                case 0x13:
                    name = "Super Jump";
                    break;
                case 0x14:
                    name = "Super Jump Forward";
                    break;
                case 0x15:
                    name = "Super Jump Backward";
                    break;
                case 0x16:
                    name = "Post Action Fall";
                    break;
                case 0x17:
                    name = "Normal Landing";
                    break;
                case 0x18:
                    name = "Turn";
                    break;
                case 0x19:
                    name = "Crouching Idle";
                    break;
                case 0x1A:
                    name = "Crouching Turn";
                    break;

                case 0x1E:
                    name = "Guard Standing";
                    break;
                case 0x1F:
                    name = "Guard Crouching";
                    break;
                case 0x20:
                    name = "Guard Midair";
                    break;
                case 0x21:
                    name = "Pushblock Standing";
                    break;
                case 0x22:
                    name = "Pushblock Crouching";
                    break;
                case 0x23:
                    name = "Pushblock Midair";
                    break;
                case 0x24:
                    name = "Throw Escape - Thrower";
                    break;
                case 0x25:
                    name = "Throw Escape - Breaker";
                    break;
                case 0x26:
                    name = "Air Throw Escape - Thrower";
                    break;
                case 0x27:
                    name = "Air Throw Escape - Breaker";
                    break;
                case 0x28:
                    name = "Guard Standing B";
                    break;
                case 0x29:
                    name = "Guard Crouching B";
                    break;
                case 0x2A:
                    name = "Guard Midair B";
                    break;

                case 0x32:
                    name = "Air Recovery";
                    break;
                case 0x33:
                    name = "Air Recovery Forward";
                    break;
                case 0x34:
                    name = "Air Recovery Backward";
                    break;
                case 0x35:
                    name = "Knockdown Recovery";
                    break;
                case 0x36:
                    name = "Knockdown Recovery Forward A";
                    break;
                case 0x37:
                    name = "Knockdown Recovery Forward B";
                    break;
                case 0x38:
                    name = "Knockdown Recovery Backward";
                    break;

                case 0x72:
                    name = "Dead Body Vanish";
                    break;

                case 0x82:
                    name = "Fight Intro - Point";
                    break;
                case 0x83:
                    name = "Fight Intro - A1";
                    break;
                case 0x84:
                    name = "Fight Intro - A2";
                    break;
                case 0x85:
                    name = "Fight Intro - Tag Out";
                    break;

                /*
                case 0x3:
                    return "fwd dash";
                case 0x4:
                    return "backdash";
                case 0x96:
                    return "5L";
                case 0x168:
                    return "5S";*/
                case 0x87:
                    name = "Taunt";
                    break;
                case 0x88:
                    name = "Vanish?";
                    break;
                case 0x89:
                    name = "Victory";
                    break;

                case 0x8B:
                    name = "Time Over Loss";
                    break;
                case 0xAB:
                    name = "SnapBack";
                    break;
                case 0xAC:
                    name = "Assist Alpha";
                    break;
                case 0xAD:
                    name = "Assist Beta";
                    break;
                case 0xAE:
                    name = "Assist Gamma";
                    break;
                case 0x1B8:
                    name = "Usually Gallery Bios Pose";
                    break;
                default:
                    name = "unknown";
                    break;
            }
        }

        //TODO: try and implement to use char name
        public virtual string GuessStatusFieldName(string filePath)
        {
            string name = "unknown";
            if (index >= 0)
            {
                string nameAfterChr = Tools.getBetween(filePath, "chr\\","\\");
                string nameAfterMod = Tools.getBetween(filePath, "mod\\","\\");
                name = !String.IsNullOrWhiteSpace(nameAfterChr) ? nameAfterChr : !String.IsNullOrWhiteSpace(nameAfterMod) ? 
                    new string(nameAfterMod.Where(c => char.IsLetter(c)).ToArray()) : "Form #" + (index + 1);
                return index > 0 ? name.GuessSecondForm(index).FirstCharToUpper() : name.FirstCharToUpper();
            }
            return name;
        }

        public virtual string GuessAnmChrEntry(string currentEntry)
        {
            //if (currentEntry.Contains())
            //{

            //}
            return currentEntry;
        }

        public virtual string GuessFieldName()
        {
            switch (index)
            {

                case 0:
                    name = "Tag-in";
                    break;
                case 1:
                    name = "TAC partner tag-in";
                    break;
                /*case 2:
                    name = "";
                    break;*/
                case 3:
                    name = "Snap Back";
                    break;
                case 4:
                    name = "st.S";
                    break;
                case 5:
                    name = "Team Aerial Counter";
                    break;
                case 6:
                    name = "TAC Up";
                    break;
                case 7:
                    name = "TAC Side";
                    break;
                 case 8:
                    name = "TAC Down";
                    break; 
                /*case 9:
                    name = "Fall";
                    break;
                case 10:
                    name = "Crouch";
                    break;
                case 11:
                    name = "";
                    break;*/
                case 30:
                    name = "st.L";
                    break;
                case 31:
                    name = "st.M";
                    break;
                case 32:
                    name = "st.H";
                    break;
                case 33:
                    name = "cr.L";
                    break;
                case 34:
                    name = "cr.M";
                    break;
                case 35:
                    name = "cr.H";
                    break;
                case 36:
                    name = "j.L";
                    break;
                case 37:
                    name = "j.M";
                    break;
                case 38:
                    name = "j.H";
                    break;
                case 39:
                    name = "j.S";
                    break;

                /*case 0x0:
                return "stand";
            case 0x1:
                return "fwd walk";
            case 0x3:
                return "fwd dash";
            case 0x4:
                return "backdash";
            case 0x96:
                return "5L";
            case 0x168:
                return "5S";*/
                default:
                    name = "unknown";
                    break;
            }

            if ((index >= 40 && index <= 49) && HasAtkFlags())
            {
                return "Command Move " + (index - 39);
            }

            if ((index >= 50 && index <= 79) && HasAtkFlags())
            {
                return "Special Move " + (index - 49);
            }

            if ((index >= 80 && index <= 99) && HasAtkFlags())
            {
                return "Hyper Move " + (index - 79);
            }

            if (index >= 100 && index <=102 && HasAtkFlags())
            {
                return "Assist " + (index - 99);
            }

            return name;
        }

        public virtual string GetFancyName()
        {
            nameSB = nameSB == null ? new StringBuilder() : nameSB.Clear();
            nameSB.Append(index.ToString("X3"));
            nameSB.Append("h: ");

            if (this.GetType().ToString().Contains("Shot"))
            {
                nameSB.Clear();
                nameSB.Append(this.index == 0 ? "SHT: " : "SHTref: ");
            }

            //if (tabletype != null && tabletype.Contains("ATKInfo"))
            if (this.GetType().ToString().Contains("ATKInfo"))
            {
                nameSB.Append(GuessFieldName());
            }
            //else if (tabletype != null && tabletype.Contains("Status"))
            else if (this.GetType().ToString().Contains("Status"))
            {
                nameSB.Append(GuessStatusFieldName(filePath));
            }
            else
            {
            nameSB.Append(name);
            }
            if (this.GetType().ToString().Contains("cmdspatk"))
            {
                return GuessAnmChrEntry(nameSB.ToString());
            }
            return  nameSB.ToString();
        }

        public virtual string GetFilename()
        {
            if(name == "unknown")
            {
                return index.ToString("X3") + "unk";
            }
            else
            {
                return name;
            }
        }

        public virtual byte[] GetData()
        {
            throw new NotImplementedException();
        }

        public virtual void SetData(byte[] newdata)
        {
            // need to set size here too
            throw new NotImplementedException();
        }

        public void Export(string filename)
        {
            AELogger.Log("exporting " + GetFancyName() + " to " + filename);
            if (File.Exists(filename))
            {
                try
                {
                    File.Copy(filename, "exportbackup", true);
                }
                catch (UnauthorizedAccessException e)
                {
                    AELogger.Log("unable to access export backup: " + e.Message);
                }

            }
            Stream t = new FileStream(filename + ".temp", FileMode.Create);
            BinaryWriter b = new BinaryWriter(t);

            b.Write(GetData());

            b.Close();
            t.Close();
            File.Copy(filename + ".temp", filename, true);
            File.Delete(filename + ".temp");
        }

        public void Import(string filename)
        {
            if (File.Exists(filename))
            {
                AELogger.Log("importing file " + filename + " to " + GetFancyName());
                using (BinaryReader reader = new BinaryReader(File.OpenRead(filename)))
                {
                    if (reader.BaseStream.Length == 0)
                    {
                        bHasData = false;
                        name = "***EMPTY DATA ***";
                    }
                    else
                    {
                        if (!bHasData)
                        {
                            bHasData = true;
                            try
                            {
                                name = Path.GetFileNameWithoutExtension(filename);
                            }
                            catch
                            {
                                GuessName();
                            }
                        }
                        ImportBytes(reader.ReadBytes((int)reader.BaseStream.Length));
                    }
                }
            }
            else
            {
                AELogger.Log("attempted import of nonexistent file " + filename + " to " + GetFancyName());
            }
        }

        public virtual void ImportBytes(byte[] bytes)
        {
            SetData(bytes);
        }

        public virtual TableEntry Duplicate()
        {
            TableEntry dupe = (TableEntry)Activator.CreateInstance(GetType());
            dupe.name = "duplicate " + name;
            dupe.size = size;
            dupe.ImportBytes(GetData());
            return dupe;
        }

        public virtual void UpdateSize()
        {

        }

        public virtual Boolean HasAtkFlags()
        {
            if ((((MarvelData.StructEntry<MarvelData.ATKInfoChunk>)this).@data).atkflags != 0)
            {
                return true;
            }
            return false;
        }
        
        public virtual int getSpatkHeaderSize()
        {
            if ((((MarvelData.StructEntry<MarvelData.SpatkHeaderChunk>)this).@data).size != 0)
            {
                return (((MarvelData.StructEntry<MarvelData.SpatkHeaderChunk>)this).@data).size;
            }
            return 0;
        }    
                
        public virtual void setSpatkHeaderSize(int newSize)
        {
            if ((((MarvelData.StructEntry<MarvelData.SpatkHeaderChunk>)this).@data).size != 0)
            {
                (((MarvelData.StructEntry<MarvelData.SpatkHeaderChunk>)this).@data).size = newSize;
            }
        }    

        public virtual int getCmdComboSpatkHeaderSize()
        {
            if ((((MarvelData.StructEntry<MarvelData.CmdComboHeaderChunk>)this).@data).size != 0)
            {
                return (((MarvelData.StructEntry<MarvelData.CmdComboHeaderChunk>)this).@data).size;
            }
            return 0;
        }
        
        public virtual void setCmdComboSpatkHeaderSize(int newSize)
        {
            if ((((MarvelData.StructEntry<MarvelData.CmdComboHeaderChunk>)this).@data).size != 0)
            {
                (((MarvelData.StructEntry<MarvelData.CmdComboHeaderChunk>)this).@data).size = newSize;
            }
        }    

        public virtual StructEntry<SpatkHeaderChunk> getSpatkHeader()
        {
            throw new NotImplementedException();
        }
        
        public virtual StructEntry<CollisionHeaderChunk> getCollisionHeader()
        {
            throw new NotImplementedException();
        }
    }
}
