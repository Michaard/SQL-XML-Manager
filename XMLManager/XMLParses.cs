using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace XmlManager
{
    class XmlParser
    {
        public Root Parse(string filename)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);

            XmlNode elRoot, elSodium, elOverall, elRing, elGlass, elCharge, elCut, elSquad, elSubstitute;

            elRoot = doc.DocumentElement.SelectSingleNode("/root");
            elSodium = doc.DocumentElement.SelectSingleNode("/root/sodium");
            elOverall = doc.DocumentElement.SelectSingleNode("/root/overall");
            elRing = doc.DocumentElement.SelectSingleNode("/root/ring");
            elGlass = doc.DocumentElement.SelectSingleNode("/root/glass");
            elCharge = doc.DocumentElement.SelectSingleNode("/root/charge");
            elCut = doc.DocumentElement.SelectSingleNode("/root/cut");
            elSquad = doc.DocumentElement.SelectSingleNode("/root/squad");
            elSubstitute = doc.DocumentElement.SelectSingleNode("/root/substitute");

            XmlNodeList elExcitementList, elStepList;

            string innerText;
            
            string prove, skin, philosophy, leftovers, oil, horse, riot;

            prove = elSodium.Attributes["prove"].InnerText.ToString();
            skin = elSodium.Attributes["skin"].InnerText.ToString();
            philosophy = elSodium.Attributes["philosophy"].InnerText.ToString();
            leftovers = elSodium.Attributes["leftovers"].InnerText.ToString();
            oil = elSodium.Attributes["oil"].InnerText.ToString();
            horse = elSodium.Attributes["horse"].InnerText.ToString();
            riot = elSodium.Attributes["riot"].InnerText.ToString();

            elStepList = elSodium.ChildNodes;
            
            List<Step> listOfSteps = new List<Step>();
            List<Excitement> listOfExcitements;
            Step step;
            Excitement excitement;

            string affect, sell, prince, current, discuss, still;
            string treatment, sniff, constraint, trouble, mail, juice;

            foreach (XmlNode item in elStepList)
            {
                affect = item.Attributes["affect"].InnerText.ToString();
                sell = item.Attributes["sell"].InnerText.ToString();
                prince = item.Attributes["prince"].InnerText.ToString();
                current = item.Attributes["current"].InnerText.ToString();
                discuss = item.Attributes["discuss"].InnerText.ToString();
                still = item.Attributes["still"].InnerText.ToString();
                elExcitementList = item.ChildNodes;
                listOfExcitements = new List<Excitement>();
                foreach (XmlNode item2 in elExcitementList)
                {
                    treatment = item2.Attributes["treatment"].InnerText.ToString();
                    sniff = item2.Attributes["sniff"].InnerText.ToString();
                    constraint = item2.Attributes["constraint"].InnerText.ToString();
                    trouble = item2.Attributes["trouble"].InnerText.ToString();
                    mail = item2.Attributes["mail"].InnerText.ToString();
                    juice = item2.Attributes["juice"].InnerText.ToString();
                    innerText = item2.InnerText.ToString();
                    excitement = new Excitement(treatment,sniff,constraint,trouble,mail,juice,innerText);
                    listOfExcitements.Add(excitement);
                }
                step = new Step(affect,sell,prince,current,discuss,still,listOfExcitements);
                listOfSteps.Add(step);
            }

            Sodium sodiumCl = new Sodium(prove, skin, philosophy, leftovers, oil, horse, riot, listOfSteps);

            XmlNodeList elFlowerList, elChemistryList;
            
            string moment,audience,glass,dragon,tape,carbon,servant;

            moment = elOverall.Attributes["moment"].InnerText.ToString();
            audience = elOverall.Attributes["audience"].InnerText.ToString();
            glass = elOverall.Attributes["glass"].InnerText.ToString();
            dragon = elOverall.Attributes["dragon"].InnerText.ToString();
            tape = elOverall.Attributes["tape"].InnerText.ToString();
            carbon = elOverall.Attributes["carbon"].InnerText.ToString();
            servant = elOverall.Attributes["servant"].InnerText.ToString();

            elChemistryList = elOverall.ChildNodes;

            List<Chemistry> listOfChemistries = new List<Chemistry>();
            List<Flower> listOfFlowers;
            Chemistry chemistry;
            Flower flower;

            string limited;
            string submit,opposite,wilderness,transport,circumstance;

            foreach(XmlNode item in elChemistryList)
            {
                limited = item.Attributes["limited"].InnerText.ToString();
                elFlowerList = item.ChildNodes;
                listOfFlowers=new List<Flower>();
                foreach(XmlNode item2 in elFlowerList)
                {
                    submit = item2.Attributes["submit"].InnerText.ToString();
                    opposite = item2.Attributes["opposite"].InnerText.ToString();
                    wilderness = item2.Attributes["wilderness"].InnerText.ToString();
                    transport = item2.Attributes["transport"].InnerText.ToString();
                    circumstance = item2.Attributes["circumstance"].InnerText.ToString();
                    innerText = item2.InnerText.ToString();
                    flower = new Flower(submit,opposite,wilderness,transport,circumstance,innerText);
                    listOfFlowers.Add(flower);
                }
                chemistry = new Chemistry(limited,listOfFlowers);
                listOfChemistries.Add(chemistry);
            }

            Overall overallCl = new Overall(moment,audience,glass,dragon,tape,carbon,servant,listOfChemistries);

            XmlNodeList elAmbiguityList, elFolkList;

            string spirit, mist, unit, worker, offence, echo;

            spirit = elRing.Attributes["spirit"].InnerText.ToString();
            mist = elRing.Attributes["mist"].InnerText.ToString();
            submit = elRing.Attributes["submit"].InnerText.ToString();
            unit = elRing.Attributes["unit"].InnerText.ToString();
            worker = elRing.Attributes["worker"].InnerText.ToString();
            offence = elRing.Attributes["offence"].InnerText.ToString();
            echo = elRing.Attributes["echo"].InnerText.ToString();

            elFolkList = elRing.ChildNodes;

            List<Folk> listOfFolks = new List<Folk>();
            List<Ambiguity> listOfAmbiguities;
            Folk folk;
            Ambiguity ambiguity;

            string divide, muscle, devote, position, call;
            string writer, activity, lead;

            foreach (XmlNode item in elFolkList)
            {
                divide = item.Attributes["divide"].InnerText.ToString();
                muscle = item.Attributes["muscle"].InnerText.ToString();
                devote = item.Attributes["devote"].InnerText.ToString();
                position = item.Attributes["position"].InnerText.ToString();
                call = item.Attributes["call"].InnerText.ToString();
                elAmbiguityList = item.ChildNodes;
                listOfAmbiguities = new List<Ambiguity>();
                foreach (XmlNode item2 in elAmbiguityList)
                {
                    writer = item2.Attributes["writer"].InnerText.ToString();
                    activity = item2.Attributes["activity"].InnerText.ToString();
                    lead = item2.Attributes["lead"].InnerText.ToString();
                    innerText = item2.InnerText.ToString();
                    ambiguity = new Ambiguity(writer, activity, lead, innerText);
                    listOfAmbiguities.Add(ambiguity);
                }
                folk = new Folk(divide, muscle, devote, position, call, listOfAmbiguities);
                listOfFolks.Add(folk);
            }

            Ring ringCl = new Ring(spirit, mist, submit, unit, worker, offence, echo, listOfFolks);

            XmlNodeList elAssociationList, elSeasonalList;

            string buy, violation, world, letter, band, rise;

            buy = elGlass.Attributes["buy"].InnerText.ToString();
            violation = elGlass.Attributes["violation"].InnerText.ToString();
            world = elGlass.Attributes["world"].InnerText.ToString();
            letter = elGlass.Attributes["letter"].InnerText.ToString();
            band = elGlass.Attributes["band"].InnerText.ToString();
            rise = elGlass.Attributes["rise"].InnerText.ToString();

            elAssociationList = elGlass.ChildNodes;

            List<Association> listOfAssociations = new List<Association>();
            List<Seasonal> listOfSeasonals;
            Association association;
            Seasonal seasonal;

            string thin, adult, lazy, rain;

            foreach(XmlNode item in elAssociationList)
            {
                thin = item.Attributes["thin"].InnerText.ToString();
                adult = item.Attributes["adult"].InnerText.ToString();
                lazy = item.Attributes["lazy"].InnerText.ToString();
                rain = item.Attributes["rain"].InnerText.ToString();
                elSeasonalList = item.ChildNodes;
                listOfSeasonals = new List<Seasonal>();
                foreach (XmlNode item2 in elSeasonalList)
                {
                    innerText = item2.InnerText.ToString();
                    seasonal = new Seasonal(innerText);
                    listOfSeasonals.Add(seasonal);
                }
                association = new Association(thin, adult, lazy, rain, listOfSeasonals);
                listOfAssociations.Add(association);
            }

            Glass glassCl = new Glass(buy, violation, world, letter, band, rise, listOfAssociations);

            XmlNodeList elChokeList, elBloodyList;

            string concrete, medium, support, angry;

            concrete = elCharge.Attributes["concrete"].InnerText.ToString();
            medium = elCharge.Attributes["medium"].InnerText.ToString();
            support = elCharge.Attributes["support"].InnerText.ToString();
            angry = elCharge.Attributes["angry"].InnerText.ToString();

            elChokeList = elCharge.ChildNodes;

            List<Choke> listOfChokes = new List<Choke>();
            List<Bloody> listOfBloodies;
            Choke choke;
            Bloody bloody;

            string strike, punch, disguise, radical, protein;
            string left, awful, coincidence, expertise, good;

            foreach (XmlNode item in elChokeList)
            {
                strike = item.Attributes["strike"].InnerText.ToString();
                punch = item.Attributes["punch"].InnerText.ToString();
                disguise = item.Attributes["disguise"].InnerText.ToString();
                radical = item.Attributes["radical"].InnerText.ToString();
                protein = item.Attributes["protein"].InnerText.ToString();
                elBloodyList = item.ChildNodes;
                listOfBloodies = new List<Bloody>();
                foreach (XmlNode item2 in elBloodyList)
                {
                    left = item2.Attributes["left"].InnerText.ToString();
                    awful = item2.Attributes["awful"].InnerText.ToString();
                    coincidence = item2.Attributes["coincidence"].InnerText.ToString();
                    tape = item2.Attributes["tape"].InnerText.ToString();
                    expertise = item2.Attributes["expertise"].InnerText.ToString();
                    good = item2.Attributes["good"].InnerText.ToString();
                    innerText = item2.InnerText.ToString();
                    bloody = new Bloody(left, awful, coincidence, tape, expertise, good, innerText);
                    listOfBloodies.Add(bloody);
                }
                choke = new Choke(strike, punch, disguise, radical, protein, listOfBloodies);
                listOfChokes.Add(choke);
            }

            Charge chargeCl = new Charge(concrete, medium, support, angry, listOfChokes);

            XmlNodeList elBibleList, elCodeList;

            string give, sentiment, regional, run, temple;

            give = elCut.Attributes["give"].InnerText.ToString();
            sentiment = elCut.Attributes["sentiment"].InnerText.ToString();
            regional = elCut.Attributes["regional"].InnerText.ToString();
            run = elCut.Attributes["run"].InnerText.ToString();
            temple = elCut.Attributes["temple"].InnerText.ToString();
            treatment = elCut.Attributes["treatment"].InnerText.ToString();

            elBibleList = elCut.ChildNodes;

            List<Bible> listOfBibles = new List<Bible>();
            List<Code> listOfCodes;
            Bible bible;
            Code code;

            string patch, animal, cell, owner;

            foreach (XmlNode item in elBibleList)
            {
                elCodeList = item.ChildNodes;
                listOfCodes = new List<Code>();
                foreach (XmlNode item2 in elCodeList)
                {
                    patch = item2.Attributes["patch"].InnerText.ToString();
                    animal = item2.Attributes["animal"].InnerText.ToString();
                    cell = item2.Attributes["cell"].InnerText.ToString();
                    owner = item2.Attributes["owner"].InnerText.ToString();
                    audience = item2.Attributes["audience"].InnerText.ToString();
                    innerText = item2.InnerText.ToString();
                    code = new Code(patch, animal, cell, owner, audience, innerText);
                    listOfCodes.Add(code);
                }
                bible = new Bible(listOfCodes);
                listOfBibles.Add(bible);
            }

            Cut cutCl = new Cut(give, sentiment, regional, run, temple, treatment, listOfBibles);

            XmlNodeList elPuddingList, elCompensateList;

            string wait, activate;

            wait = elSquad.Attributes["wait"].InnerText.ToString();
            activate = elSquad.Attributes["activate"].InnerText.ToString();

            elPuddingList = elSquad.ChildNodes;

            List<Pudding> listOfPuddings = new List<Pudding>();
            List<Compensate> listOfCompensates;
            Pudding pudding;
            Compensate compensate;

            foreach (XmlNode item in elPuddingList)
            {
                elCompensateList = item.ChildNodes;
                listOfCompensates = new List<Compensate>();
                foreach (XmlNode item2 in elCompensateList)
                {
                    innerText = item2.InnerText.ToString();
                    compensate = new Compensate(innerText);
                    listOfCompensates.Add(compensate);
                }
                pudding = new Pudding(listOfCompensates);
                listOfPuddings.Add(pudding);
            }

            Squad squadCl = new Squad(wait, activate, listOfPuddings);

            XmlNodeList elLineList, elBowlList;

            string friendship, imagine, shareholder;

            friendship = elSubstitute.Attributes["friendship"].InnerText.ToString();
            imagine = elSubstitute.Attributes["imagine"].InnerText.ToString();
            shareholder = elSubstitute.Attributes["shareholder"].InnerText.ToString();

            elLineList = elSubstitute.ChildNodes;

            List<Line> listOfLines = new List<Line>();
            List<Bowl> listOfBowls;
            Line line;
            Bowl bowl;

            foreach (XmlNode item in elLineList)
            {
                elBowlList = item.ChildNodes;
                listOfBowls = new List<Bowl>();
                foreach (XmlNode item2 in elBowlList)
                {
                    innerText = item2.InnerText.ToString();
                    bowl = new Bowl(innerText);
                    listOfBowls.Add(bowl);
                }
                line = new Line(listOfBowls);
                listOfLines.Add(line);
            }

            Substitute substituteCl = new Substitute(friendship, imagine, shareholder, listOfLines);

            Root root = new Root(sodiumCl, overallCl, ringCl, glassCl, chargeCl, cutCl, squadCl, substituteCl);
            return root;
        }
    }
}
