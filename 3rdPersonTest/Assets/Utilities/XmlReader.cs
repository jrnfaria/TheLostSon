using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

//read state xml;

public class startcondition{
	[XmlAttribute("type")]
	public string type;

	public int questId;
}

public class objective{
	[XmlAttribute("type")]
	public string type;
	
	public int quantity;
}

public class reward{
	public string money;
	
	public int exp;
}

[XmlRoot("quest")]
public class Container
{
	public int id;

	[XmlArray("startconditions")]
	[XmlArrayItem("startcondition")]
	public List<startcondition> startconditions = new List<startcondition>();

	public string description;
	
	[XmlAttribute("type")]
	public string type;

	[XmlElement("objective")]
	public objective obj;

	[XmlElement("reward")]
	public reward rew;
}

public class XmlReader : MonoBehaviour {
	
	public Container container;

	public void read (string name) {

		//read xml
		var serializer = new XmlSerializer (typeof(Container));
		var stream = new FileStream (Application.dataPath + "/QuestsList/"+"Quest 1"+".xml", FileMode.Open);
		container = serializer.Deserialize (stream) as Container;
		stream.Close ();


	}

	// Update is called once per frame
	void Update () {
	
	}
}
