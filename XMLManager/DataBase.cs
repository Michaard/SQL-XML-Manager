﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;

namespace XmlManager
{
    class DataBase
    {
        private string SERVER = "win-uk8cttndcgq";
        private string XMLDATABASE = "XMLData";

        public string ConnectionString(string server,string database)
        {
            return "server="+server+"; database="+database+";Trusted_Connection=True;";
        }

        private bool TestConnection(string server, string database)
        {
            try
            {
                SqlConnection connection = new SqlConnection(ConnectionString(server,database));
                connection.Open();
                connection.Close();
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Błąd połączenia z bazą danych.");
                Console.ReadLine();
                return false;
            }
        }

        public void InsertIntoXmlDatabase(Root root)
        {
            try
            {
                if (this.TestConnection(SERVER, XMLDATABASE))
                {
                    SqlConnection connection = new SqlConnection(ConnectionString(SERVER, XMLDATABASE));
                    connection.Open();

                    string query = "INSERT INTO XMLData.dbo.TSodium VALUES ( '" +
                        root.Sodium.Prove + "', '" + root.Sodium.Skin + "', '" + root.Sodium.Philosophy + "', '" + root.Sodium.Leftovers + "', '" + root.Sodium.Oil + "', '" + root.Sodium.Horse + "', '" + root.Sodium.Riot
                        + "'); ";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    int stepId = 1;
                    foreach (Step step in root.Sodium.ListOfSteps)
                    {
                        query = "INSERT INTO XMLData.dbo.TSodiumStep VALUES ( " +
                            stepId + ", '" + step.Affect + "', '" + step.Sell + "', '" + step.Prince + "', '" + step.Current + "', '" + step.Discuss + "', '" + step.Still
                            + "'); ";
                        cmd = new SqlCommand(query, connection);
                        cmd.ExecuteNonQuery();

                        foreach (Excitement excitement in step.ListOfExcitements)
                        {
                            query = "INSERT INTO XMLData.dbo.TSodiumStepExcitement VALUES ( " +
                                stepId + ", '" + excitement.Treatment + "', '" + excitement.Sniff + "', '" + excitement.Constraint + "', '" + excitement.Trouble + "', '" + excitement.Mail + "', '" + excitement.Juice + "', '" + excitement.InnerText
                                + "'); ";
                            cmd = new SqlCommand(query, connection);
                            cmd.ExecuteNonQuery();
                        }

                        stepId++;
                    }

                    query = "INSERT INTO XMLData.dbo.TOverall VALUES ( '" +
                        root.Overall.Moment + "', '" + root.Overall.Audience + "', '" + root.Overall.Glass + "', '" + root.Overall.Dragon + "', '" + root.Overall.Tape + "', '" + root.Overall.Carbon + "', '" + root.Overall.Servant
                        + "'); ";
                    cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    int chemistryId = 1;
                    foreach (Chemistry chemistry in root.Overall.ListOfChemistries)
                    {
                        query = "INSERT INTO XMLData.dbo.TOverallChemistry VALUES ( " +
                            chemistryId + ", '" + chemistry.Limited
                            + "'); ";
                        cmd = new SqlCommand(query, connection);
                        cmd.ExecuteNonQuery();

                        foreach (Flower flower in chemistry.ListOfFlowers)
                        {
                            query = "INSERT INTO XMLData.dbo.TOverallChemistryFlower VALUES ( " +
                                chemistryId + ", '" + flower.Submit + "', '" + flower.Opposite + "', '" + flower.Wilderness + "', '" + flower.Transport + "', '" + flower.Circumstance + "', '" + flower.InnerText
                                + "'); ";
                            cmd = new SqlCommand(query, connection);
                            cmd.ExecuteNonQuery();
                        }

                        chemistryId++;
                    }

                    query = "INSERT INTO XMLData.dbo.TRing VALUES ( '" +
                        root.Ring.Spirit + "', '" + root.Ring.Mist + "', '" + root.Ring.Submit + "', '" + root.Ring.Unit + "', '" + root.Ring.Worker + "', '" + root.Ring.Offence + "', '" + root.Ring.Echo
                        + "'); ";
                    cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    int folkId = 1;
                    foreach (Folk folk in root.Ring.ListOfFolks)
                    {
                        query = "INSERT INTO XMLData.dbo.TRingFolk VALUES ( " +
                            folkId + ", '" + folk.Divide + "', '" + folk.Muscle + "', '" + folk.Devote + "', '" + folk.Position + "', '" + folk.Call
                            + "'); ";
                        cmd = new SqlCommand(query, connection);
                        cmd.ExecuteNonQuery();

                        foreach (Ambiguity ambiguity in folk.ListOfAmbiguities)
                        {
                            query = "INSERT INTO XMLData.dbo.TRingFolkAmbiguity VALUES ( " +
                                folkId + ", '" + ambiguity.Writer + "', '" + ambiguity.Activity + "', '" + ambiguity.Lead + "', '" + ambiguity.InnerText
                                + "'); ";
                            cmd = new SqlCommand(query, connection);
                            cmd.ExecuteNonQuery();
                        }

                        folkId++;
                    }

                    query = "INSERT INTO XMLData.dbo.TGlass VALUES ( '" +
                        root.Glass.Buy + "', '" + root.Glass.Violation + "', '" + root.Glass.World + "', '" + root.Glass.Letter + "', '" + root.Glass.Band + "', '" + root.Glass.Rise
                        + "'); ";
                    cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    int associationId = 1;
                    foreach (Association association in root.Glass.ListOfAssociations)
                    {
                        query = "INSERT INTO XMLData.dbo.TGlassAssociation VALUES ( " +
                            associationId + ", '" + association.Thin + "', '" + association.Adult + "', '" + association.Lazy + "', '" + association.Rain
                            + "'); ";
                        cmd = new SqlCommand(query, connection);
                        cmd.ExecuteNonQuery();

                        foreach (Seasonal seasonal in association.ListOfSeasonals)
                        {
                            query = "INSERT INTO XMLData.dbo.TGlassAssociationSeasonal VALUES ( " +
                                associationId + ", '" + seasonal.InnerText
                                + "'); ";
                            cmd = new SqlCommand(query, connection);
                            cmd.ExecuteNonQuery();
                        }

                        associationId++;
                    }

                    query = "INSERT INTO XMLData.dbo.TCharge VALUES ( '" +
                        root.Charge.Concrete + "', '" + root.Charge.Medium + "', '" + root.Charge.Support + "', '" + root.Charge.Angry
                        + "'); ";
                    cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    int chokeId = 1;
                    foreach (Choke choke in root.Charge.ListOfChokes)
                    {
                        query = "INSERT INTO XMLData.dbo.TChargeChoke VALUES ( " +
                            chokeId + ", '" + choke.Strike + "', '" + choke.Punch + "', '" + choke.Disguise + "', '" + choke.Radical + "', '" + choke.Protein
                            + "'); ";
                        cmd = new SqlCommand(query, connection);
                        cmd.ExecuteNonQuery();

                        foreach (Bloody bloody in choke.ListOfBloodies)
                        {
                            query = "INSERT INTO XMLData.dbo.TChargeChokeBloody VALUES ( " +
                                chokeId + ", '" + bloody.Left + "', '" + bloody.Awful + "', '" + bloody.Coincidence + "', '" + bloody.Tape + "', '" + bloody.Expertise + "', '" + bloody.Good + "', '" + bloody.InnerText
                                + "'); ";
                            cmd = new SqlCommand(query, connection);
                            cmd.ExecuteNonQuery();
                        }

                        chokeId++;
                    }

                    query = "INSERT INTO XMLData.dbo.TCut VALUES ( '" +
                        root.Cut.Give + "', '" + root.Cut.Sentiment + "', '" + root.Cut.Regional + "', '" + root.Cut.Run + "', '" + root.Cut.Temple + "', '" + root.Cut.Treatment
                        + "'); ";
                    cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    int bibleId = 1;
                    foreach (Bible bible in root.Cut.ListOfBibles)
                    {
                        query = "INSERT INTO XMLData.dbo.TCutBible VALUES ( " +
                            bibleId
                            + "); ";
                        cmd = new SqlCommand(query, connection);
                        cmd.ExecuteNonQuery();

                        foreach (Code code in bible.ListOfCodes)
                        {
                            query = "INSERT INTO XMLData.dbo.TCutBibleCode VALUES ( " +
                                bibleId + ", '" + code.Patch + "', '" + code.Animal + "', '" + code.Cell + "', '" + code.Owner + "', '" + code.Audience + "', '" + code.InnerText
                                + "'); ";
                            cmd = new SqlCommand(query, connection);
                            cmd.ExecuteNonQuery();
                        }

                        bibleId++;
                    }

                    query = "INSERT INTO XMLData.dbo.TSquad VALUES ( '" +
                        root.Squad.Wait + "', '" + root.Squad.Activate
                        + "'); ";
                    cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    int puddingId = 1;
                    foreach (Pudding pudding in root.Squad.ListOfPuddings)
                    {
                        query = "INSERT INTO XMLData.dbo.TSquadPudding VALUES ( " +
                            puddingId
                            + "); ";
                        cmd = new SqlCommand(query, connection);
                        cmd.ExecuteNonQuery();

                        foreach (Compensate compensate in pudding.ListOfCompensates)
                        {
                            query = "INSERT INTO XMLData.dbo.TSquadPuddingCompensate VALUES ( " +
                                puddingId + ", '" + compensate.InnerText
                                + "'); ";
                            cmd = new SqlCommand(query, connection);
                            cmd.ExecuteNonQuery();
                        }

                        puddingId++;
                    }

                    query = "INSERT INTO XMLData.dbo.TSubstitute VALUES ( '" +
                        root.Substitute.Friendship + "', '" + root.Substitute.Imagine + "', '" + root.Substitute.Shareholder
                        + "'); ";
                    cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    int lineId = 1;
                    foreach (Line line in root.Substitute.ListOfLines)
                    {
                        query = "INSERT INTO XMLData.dbo.TSubstituteLine VALUES ( " +
                            lineId
                            + "); ";
                        cmd = new SqlCommand(query, connection);
                        cmd.ExecuteNonQuery();

                        foreach (Bowl bowl in line.ListOfBowls)
                        {
                            query = "INSERT INTO XMLData.dbo.TSubstituteLineBowl VALUES ( " +
                                lineId + ", '" + bowl.InnerText
                                + "'); ";
                            cmd = new SqlCommand(query, connection);
                            cmd.ExecuteNonQuery();
                        }

                        lineId++;
                    }

                    connection.Close();

                    Console.WriteLine("Insert complete!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }

        public void ClearXmlDatabase()
        {
            try
            {
                if (this.TestConnection(SERVER, XMLDATABASE))
                {
                    SqlConnection connection = new SqlConnection(ConnectionString(SERVER, XMLDATABASE));
                    connection.Open();

                    string query = "DELETE FROM XMLData.dbo.TSodium;";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    query = "DELETE FROM XMLData.dbo.TSodiumStep;";
                    cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    query = "DELETE FROM XMLData.dbo.TSodiumStepExcitement;";
                    cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    query = "DELETE FROM XMLData.dbo.TOverall;";
                    cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    query = "DELETE FROM XMLData.dbo.TOverallChemistry;";
                    cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    query = "DELETE FROM XMLData.dbo.TOverallChemistryFlower;";
                    cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    query = "DELETE FROM XMLData.dbo.TRing;";
                    cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    query = "DELETE FROM XMLData.dbo.TRingFolk;";
                    cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    query = "DELETE FROM XMLData.dbo.TRingFolkAmbiguity;";
                    cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    query = "DELETE FROM XMLData.dbo.TGlass;";
                    cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    query = "DELETE FROM XMLData.dbo.TGlassAssociation;";
                    cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    query = "DELETE FROM XMLData.dbo.TGlassAssociationSeasonal;";
                    cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    query = "DELETE FROM XMLData.dbo.TCharge;";
                    cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    query = "DELETE FROM XMLData.dbo.TChargeChoke;";
                    cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    query = "DELETE FROM XMLData.dbo.TChargeChokeBloody;";
                    cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    query = "DELETE FROM XMLData.dbo.TCut;";
                    cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    query = "DELETE FROM XMLData.dbo.TCutBible;";
                    cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    query = "DELETE FROM XMLData.dbo.TCutBibleCode;";
                    cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    query = "DELETE FROM XMLData.dbo.TSquad;";
                    cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    query = "DELETE FROM XMLData.dbo.TSquadPudding;";
                    cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    query = "DELETE FROM XMLData.dbo.TSquadPuddingCompensate;";
                    cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    query = "DELETE FROM XMLData.dbo.TSubstitute;";
                    cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    query = "DELETE FROM XMLData.dbo.TSubstituteLine;";
                    cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    query = "DELETE FROM XMLData.dbo.TSubstituteLineBowl;";
                    cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    connection.Close();

                    Console.WriteLine("Delete complete!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }

        public Root LoadDataFromXmlDatabase()
        {
            try
            {
                if (this.TestConnection(SERVER, XMLDATABASE))
                {
                    SqlConnection connection = new SqlConnection(ConnectionString(SERVER, XMLDATABASE));
                    connection.Open();

                    string query;
                    SqlCommand cmd;
                    DataTable dt, innerDt;
                    SqlDataAdapter dataAdapter;

                    query = "SELECT * FROM XMLData.dbo.TSodiumStep;";
                    cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    dt = new DataTable("TSodiumStep");
                    dataAdapter = new SqlDataAdapter(cmd);
                    dataAdapter.Fill(dt);

                    List<Step> listOfSteps = new List<Step>();
                    List<Excitement> listOfExcitements;
                    
                    int stepId;
                    string affect, sell, prince, current, discuss, still;
                    string treatment, sniff, constraint, trouble, mail, juice, innerText;
                    
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        stepId = Convert.ToInt32(dt.Rows[i]["ID"].ToString());
                        affect = dt.Rows[i]["affect"].ToString();
                        sell = dt.Rows[i]["sell"].ToString();
                        prince = dt.Rows[i]["prince"].ToString();
                        current = dt.Rows[i]["current"].ToString();
                        discuss = dt.Rows[i]["discuss"].ToString();
                        still = dt.Rows[i]["still"].ToString();

                        listOfExcitements = new List<Excitement>();

                        query = "SELECT * FROM XMLData.dbo.TSodiumStepExcitement WHERE stepID = " + stepId + ";";
                        cmd = new SqlCommand(query, connection);
                        cmd.ExecuteNonQuery();

                        innerDt = new DataTable("TSodiumStepExcitement");
                        dataAdapter = new SqlDataAdapter(cmd);
                        dataAdapter.Fill(innerDt);

                        for (int j = 0; j < innerDt.Rows.Count; j++)
                        {
                            treatment = innerDt.Rows[j]["treatment"].ToString();
                            sniff = innerDt.Rows[j]["sniff"].ToString();
                            constraint = innerDt.Rows[j]["constraint"].ToString();
                            trouble = innerDt.Rows[j]["trouble"].ToString();
                            mail = innerDt.Rows[j]["mail"].ToString();
                            juice = innerDt.Rows[j]["juice"].ToString();
                            innerText = innerDt.Rows[j]["innerText"].ToString();

                            listOfExcitements.Add(new Excitement(treatment, sniff, constraint, trouble, mail, juice, innerText));
                        }

                        listOfSteps.Add(new Step(affect, sell, prince, current, discuss, still, listOfExcitements));
                    }

                    query = "SELECT * FROM XMLData.dbo.TSodium;";
                    cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    dt = new DataTable("TSodium");
                    dataAdapter = new SqlDataAdapter(cmd);
                    dataAdapter.Fill(dt);

                    string prove, skin, philosophy, leftovers, oil, horse, riot;
                    prove = dt.Rows[0]["prove"].ToString();
                    skin = dt.Rows[0]["skin"].ToString();
                    philosophy = dt.Rows[0]["philosophy"].ToString();
                    leftovers = dt.Rows[0]["leftovers"].ToString();
                    oil = dt.Rows[0]["oil"].ToString();
                    horse = dt.Rows[0]["horse"].ToString();
                    riot = dt.Rows[0]["riot"].ToString();

                    Sodium sodium = new Sodium(prove, skin, philosophy, leftovers, oil, horse, riot, listOfSteps);

                    query = "SELECT * FROM XMLData.dbo.TOverallChemistry;";
                    cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    dt = new DataTable("TOverallChemistry");
                    dataAdapter = new SqlDataAdapter(cmd);
                    dataAdapter.Fill(dt);

                    List<Chemistry> listOfChemistries = new List<Chemistry>();
                    List<Flower> listOfFlowers;

                    int chemistryId;
                    string limited;
                    string submit, opposite, wilderness, transport, circumstance;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        chemistryId = Convert.ToInt32(dt.Rows[i]["ID"].ToString());
                        limited = dt.Rows[i]["limited"].ToString();

                        listOfFlowers = new List<Flower>();

                        query = "SELECT * FROM XMLData.dbo.TOverallChemistryFlower WHERE chemistryID = " + chemistryId + ";";
                        cmd = new SqlCommand(query, connection);
                        cmd.ExecuteNonQuery();

                        innerDt = new DataTable("TOverallChemistryFlower");
                        dataAdapter = new SqlDataAdapter(cmd);
                        dataAdapter.Fill(innerDt);

                        for (int j = 0; j < innerDt.Rows.Count; j++)
                        {
                            submit = innerDt.Rows[j]["submit"].ToString();
                            opposite = innerDt.Rows[j]["opposite"].ToString();
                            wilderness = innerDt.Rows[j]["wilderness"].ToString();
                            transport = innerDt.Rows[j]["transport"].ToString();
                            circumstance = innerDt.Rows[j]["circumstance"].ToString();
                            innerText = innerDt.Rows[j]["innerText"].ToString();

                            listOfFlowers.Add(new Flower(submit, opposite, wilderness, transport, circumstance, innerText));
                        }

                        listOfChemistries.Add(new Chemistry(limited, listOfFlowers));
                    }

                    query = "SELECT * FROM XMLData.dbo.TOverall;";
                    cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    dt = new DataTable("TOverall");
                    dataAdapter = new SqlDataAdapter(cmd);
                    dataAdapter.Fill(dt);

                    string moment, audience, glassStr, dragon, tape, carbon, servant;
                    moment = dt.Rows[0]["moment"].ToString();
                    audience = dt.Rows[0]["audience"].ToString();
                    glassStr = dt.Rows[0]["glass"].ToString();
                    dragon = dt.Rows[0]["dragon"].ToString();
                    tape = dt.Rows[0]["tape"].ToString();
                    carbon = dt.Rows[0]["carbon"].ToString();
                    servant = dt.Rows[0]["servant"].ToString();

                    Overall overall = new Overall(moment, audience, glassStr, dragon, tape, carbon, servant, listOfChemistries);

                    query = "SELECT * FROM XMLData.dbo.TRingFolk;";
                    cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    dt = new DataTable("TRingFolk");
                    dataAdapter = new SqlDataAdapter(cmd);
                    dataAdapter.Fill(dt);

                    List<Folk> listOfFolks = new List<Folk>();
                    List<Ambiguity> listOfAmbiguities;

                    int folkId;
                    string divide, muscle, devote, position, call;
                    string writer, activity, lead;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        folkId = Convert.ToInt32(dt.Rows[i]["ID"].ToString());
                        divide = dt.Rows[i]["divide"].ToString();
                        muscle = dt.Rows[i]["muscle"].ToString();
                        devote = dt.Rows[i]["devote"].ToString();
                        position = dt.Rows[i]["position"].ToString();
                        call = dt.Rows[i]["call"].ToString();

                        listOfAmbiguities = new List<Ambiguity>();

                        query = "SELECT * FROM XMLData.dbo.TRingFolkAmbiguity WHERE folkID = " + folkId + ";";
                        cmd = new SqlCommand(query, connection);
                        cmd.ExecuteNonQuery();

                        innerDt = new DataTable("TRingFolkAmbiguity");
                        dataAdapter = new SqlDataAdapter(cmd);
                        dataAdapter.Fill(innerDt);

                        for (int j = 0; j < innerDt.Rows.Count; j++)
                        {
                            writer = innerDt.Rows[j]["writer"].ToString();
                            activity = innerDt.Rows[j]["activity"].ToString();
                            lead = innerDt.Rows[j]["lead"].ToString();
                            innerText = innerDt.Rows[j]["innerText"].ToString();

                            listOfAmbiguities.Add(new Ambiguity(writer, activity, lead, innerText));
                        }

                        listOfFolks.Add(new Folk(divide, muscle, devote, position, call, listOfAmbiguities));
                    }

                    query = "SELECT * FROM XMLData.dbo.TRing;";
                    cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    dt = new DataTable("TRing");
                    dataAdapter = new SqlDataAdapter(cmd);
                    dataAdapter.Fill(dt);

                    string spirit, mist, unit, worker, offence, echo;
                    spirit = dt.Rows[0]["spirit"].ToString();
                    mist = dt.Rows[0]["mist"].ToString();
                    submit = dt.Rows[0]["submit"].ToString();
                    unit = dt.Rows[0]["unit"].ToString();
                    worker = dt.Rows[0]["worker"].ToString();
                    offence = dt.Rows[0]["offence"].ToString();
                    echo = dt.Rows[0]["echo"].ToString();

                    Ring ring = new Ring(spirit, mist, submit, unit, worker, offence, echo, listOfFolks);

                    query = "SELECT * FROM XMLData.dbo.TGlassAssociation;";
                    cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    dt = new DataTable("TGlassAssociation");
                    dataAdapter = new SqlDataAdapter(cmd);
                    dataAdapter.Fill(dt);

                    List<Association> listOfAssociations = new List<Association>();
                    List<Seasonal> listOfSeasonals;

                    int associationId;
                    string thin, adult, lazy, rain;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        associationId = Convert.ToInt32(dt.Rows[i]["ID"].ToString());
                        thin = dt.Rows[i]["thin"].ToString();
                        adult = dt.Rows[i]["adult"].ToString();
                        lazy = dt.Rows[i]["lazy"].ToString();
                        rain = dt.Rows[i]["rain"].ToString();

                        listOfSeasonals = new List<Seasonal>();

                        query = "SELECT * FROM XMLData.dbo.TGlassAssociationSeasonal WHERE associationID = " + associationId + ";";
                        cmd = new SqlCommand(query, connection);
                        cmd.ExecuteNonQuery();

                        innerDt = new DataTable("TGlassAssociationSeasonal");
                        dataAdapter = new SqlDataAdapter(cmd);
                        dataAdapter.Fill(innerDt);

                        for (int j = 0; j < innerDt.Rows.Count; j++)
                        {
                            innerText = innerDt.Rows[j]["innerText"].ToString();

                            listOfSeasonals.Add(new Seasonal(innerText));
                        }

                        listOfAssociations.Add(new Association(thin, adult, lazy, rain, listOfSeasonals));
                    }

                    query = "SELECT * FROM XMLData.dbo.TGlass;";
                    cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    dt = new DataTable("TGlass");
                    dataAdapter = new SqlDataAdapter(cmd);
                    dataAdapter.Fill(dt);

                    string buy, violation, world, letter, band, rise;
                    buy = dt.Rows[0]["buy"].ToString();
                    violation = dt.Rows[0]["violation"].ToString();
                    world = dt.Rows[0]["world"].ToString();
                    letter = dt.Rows[0]["letter"].ToString();
                    band = dt.Rows[0]["band"].ToString();
                    rise = dt.Rows[0]["rise"].ToString();

                    Glass glass = new Glass(buy, violation, world, letter, band, rise, listOfAssociations);

                    query = "SELECT * FROM XMLData.dbo.TChargeChoke;";
                    cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    dt = new DataTable("TChargeChoke");
                    dataAdapter = new SqlDataAdapter(cmd);
                    dataAdapter.Fill(dt);

                    List<Choke> listOfChokes = new List<Choke>();
                    List<Bloody> listOfBloodies;

                    int chokeId;
                    string strike, punch, disguise, radical, protein;
                    string left, awful, coincidence, expertise, good;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        chokeId = Convert.ToInt32(dt.Rows[i]["ID"].ToString());
                        strike = dt.Rows[i]["strike"].ToString();
                        punch = dt.Rows[i]["punch"].ToString();
                        disguise = dt.Rows[i]["disguise"].ToString();
                        radical = dt.Rows[i]["radical"].ToString();
                        protein = dt.Rows[i]["protein"].ToString();

                        listOfBloodies = new List<Bloody>();

                        query = "SELECT * FROM XMLData.dbo.TChargeChokeBloody WHERE chokeID = " + chokeId + ";";
                        cmd = new SqlCommand(query, connection);
                        cmd.ExecuteNonQuery();

                        innerDt = new DataTable("TChargeChokeBloody");
                        dataAdapter = new SqlDataAdapter(cmd);
                        dataAdapter.Fill(innerDt);

                        for (int j = 0; j < innerDt.Rows.Count; j++)
                        {
                            left = innerDt.Rows[j]["left"].ToString();
                            awful = innerDt.Rows[j]["awful"].ToString();
                            coincidence = innerDt.Rows[j]["coincidence"].ToString();
                            tape = innerDt.Rows[j]["tape"].ToString();
                            expertise = innerDt.Rows[j]["expertise"].ToString();
                            good = innerDt.Rows[j]["good"].ToString();
                            innerText = innerDt.Rows[j]["innerText"].ToString();

                            listOfBloodies.Add(new Bloody(left, awful, coincidence, tape, expertise, good, innerText));
                        }

                        listOfChokes.Add(new Choke(strike, punch, disguise, radical, protein, listOfBloodies));
                    }

                    query = "SELECT * FROM XMLData.dbo.TCharge;";
                    cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    dt = new DataTable("TCharge");
                    dataAdapter = new SqlDataAdapter(cmd);
                    dataAdapter.Fill(dt);

                    string concrete, medium, support, angry;
                    concrete = dt.Rows[0]["concrete"].ToString();
                    medium = dt.Rows[0]["medium"].ToString();
                    support = dt.Rows[0]["support"].ToString();
                    angry = dt.Rows[0]["angry"].ToString();

                    Charge charge = new Charge(concrete, medium, support, angry, listOfChokes);

                    query = "SELECT * FROM XMLData.dbo.TCutBible;";
                    cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    dt = new DataTable("TCutBible");
                    dataAdapter = new SqlDataAdapter(cmd);
                    dataAdapter.Fill(dt);

                    List<Bible> listOfBibles = new List<Bible>();
                    List<Code> listOfCodes;

                    int bibleId;
                    string patch, animal, cell, owner;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        bibleId = Convert.ToInt32(dt.Rows[i]["ID"].ToString());

                        listOfCodes = new List<Code>();

                        query = "SELECT * FROM XMLData.dbo.TCutBibleCode WHERE bibleID = " + bibleId + ";";
                        cmd = new SqlCommand(query, connection);
                        cmd.ExecuteNonQuery();

                        innerDt = new DataTable("TCutBibleCode");
                        dataAdapter = new SqlDataAdapter(cmd);
                        dataAdapter.Fill(innerDt);

                        for (int j = 0; j < innerDt.Rows.Count; j++)
                        {
                            patch = innerDt.Rows[j]["patch"].ToString();
                            animal = innerDt.Rows[j]["animal"].ToString();
                            cell = innerDt.Rows[j]["cell"].ToString();
                            owner = innerDt.Rows[j]["owner"].ToString();
                            audience = innerDt.Rows[j]["audience"].ToString();
                            innerText = innerDt.Rows[j]["innerText"].ToString();

                            listOfCodes.Add(new Code(patch, animal, cell, owner, audience, innerText));
                        }

                        listOfBibles.Add(new Bible(listOfCodes));
                    }

                    query = "SELECT * FROM XMLData.dbo.TCut;";
                    cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    dt = new DataTable("TCut");
                    dataAdapter = new SqlDataAdapter(cmd);
                    dataAdapter.Fill(dt);

                    string give, sentiment, regional, run, temple;
                    give = dt.Rows[0]["give"].ToString();
                    sentiment = dt.Rows[0]["sentiment"].ToString();
                    regional = dt.Rows[0]["regional"].ToString();
                    run = dt.Rows[0]["run"].ToString();
                    temple = dt.Rows[0]["temple"].ToString();
                    treatment = dt.Rows[0]["treatment"].ToString();

                    Cut cut = new Cut(give, sentiment, regional, run, temple, treatment, listOfBibles);

                    query = "SELECT * FROM XMLData.dbo.TSquadPudding;";
                    cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    dt = new DataTable("TSquadPudding");
                    dataAdapter = new SqlDataAdapter(cmd);
                    dataAdapter.Fill(dt);

                    List<Pudding> listOfPuddings = new List<Pudding>();
                    List<Compensate> listOfCompensates;

                    int puddingId;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        puddingId = Convert.ToInt32(dt.Rows[i]["ID"].ToString());

                        listOfCompensates = new List<Compensate>();

                        query = "SELECT * FROM XMLData.dbo.TSquadPuddingCompensate WHERE puddingID = " + puddingId + ";";
                        cmd = new SqlCommand(query, connection);
                        cmd.ExecuteNonQuery();

                        innerDt = new DataTable("TSquadPuddingCompensate");
                        dataAdapter = new SqlDataAdapter(cmd);
                        dataAdapter.Fill(innerDt);

                        for (int j = 0; j < innerDt.Rows.Count; j++)
                        {
                            innerText = innerDt.Rows[j]["innerText"].ToString();

                            listOfCompensates.Add(new Compensate(innerText));
                        }

                        listOfPuddings.Add(new Pudding(listOfCompensates));
                    }

                    query = "SELECT * FROM XMLData.dbo.TSquad;";
                    cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    dt = new DataTable("TSquad");
                    dataAdapter = new SqlDataAdapter(cmd);
                    dataAdapter.Fill(dt);

                    string wait, activate;
                    wait = dt.Rows[0]["wait"].ToString();
                    activate = dt.Rows[0]["activate"].ToString();

                    Squad squad = new Squad(wait, activate, listOfPuddings);

                    query = "SELECT * FROM XMLData.dbo.TSubstituteLine;";
                    cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    dt = new DataTable("TSubstituteLine");
                    dataAdapter = new SqlDataAdapter(cmd);
                    dataAdapter.Fill(dt);

                    List<Line> listOfLines = new List<Line>();
                    List<Bowl> listOfBowls;

                    int lineId;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        lineId = Convert.ToInt32(dt.Rows[i]["ID"].ToString());

                        listOfBowls = new List<Bowl>();

                        query = "SELECT * FROM XMLData.dbo.TSubstituteLineBowl WHERE lineID = " + lineId + ";";
                        cmd = new SqlCommand(query, connection);
                        cmd.ExecuteNonQuery();

                        innerDt = new DataTable("TSubstituteLineBowl");
                        dataAdapter = new SqlDataAdapter(cmd);
                        dataAdapter.Fill(innerDt);

                        for (int j = 0; j < innerDt.Rows.Count; j++)
                        {
                            innerText = innerDt.Rows[j]["innerText"].ToString();

                            listOfBowls.Add(new Bowl(innerText));
                        }

                        listOfLines.Add(new Line(listOfBowls));
                    }

                    query = "SELECT * FROM XMLData.dbo.TSubstitute;";
                    cmd = new SqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    dt = new DataTable("TSubstitute");
                    dataAdapter = new SqlDataAdapter(cmd);
                    dataAdapter.Fill(dt);

                    string friendship, imagine, shareholder;
                    friendship = dt.Rows[0]["friendship"].ToString();
                    imagine = dt.Rows[0]["imagine"].ToString();
                    shareholder = dt.Rows[0]["shareholder"].ToString();

                    Substitute substitute = new Substitute(friendship, imagine, shareholder, listOfLines);

                    connection.Close();

                    Root root = new Root(sodium, overall, ring, glass, charge, cut, squad, substitute);

                    return root;
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                return null;
            }
        }
    }
}
