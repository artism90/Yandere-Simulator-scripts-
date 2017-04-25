using System;
using System.Collections;
using System.IO;
using System.Xml;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

// Token: 0x02000005 RID: 5
[Serializable]
public class aoi_character_pack_v0111_scenescript : MonoBehaviour
{
	// Token: 0x0600000F RID: 15 RVA: 0x00002DDC File Offset: 0x00000FDC
	public aoi_character_pack_v0111_scenescript()
	{
		this.boneName = "Hips";
		this.camGuiRootRect = new Rect((float)870, (float)25, (float)93, (float)420);
		this.camGuiBodyRect = new Rect((float)870, (float)25, (float)93, (float)420);
		this.animSpeedGuiBodyRect = new Rect((float)770, (float)520, (float)170, (float)150);
		this.textGuiBodyRect = new Rect((float)20, (float)510, (float)300, (float)70);
		this.modelBodyRect = new Rect((float)20, (float)40, (float)300, (float)500);
		this.FBXListFile = "fbx_list";
		this.AnimationListFile = "animation_list";
		this.TitleTextFile = "title_text";
		this.guiOn = true;
		this.viewerResourcesPath = "Aoi_v0111";
		this.settingsPath = this.viewerResourcesPath + "/Viewer Settings";
		this.materialsPath = this.viewerResourcesPath + "/Viewer Materials";
		this.curBG = 1;
		this.curAnim = 1;
		this.curModel = 1;
		this.curModelName = string.Empty;
		this.curAnimName = string.Empty;
		this.curBgName = string.Empty;
		this.animSpeed = (float)1;
		this.lodList = new string[]
		{
			"_h",
			"_m",
			"_l"
		};
		this.lodTextList = new string[]
		{
			"Hi",
			"Mid",
			"Low"
		};
		this.CamModeRote = true;
		this.CamModeFix = true;
		this.titleText = string.Empty;
	}

	// Token: 0x06000010 RID: 16 RVA: 0x00002F90 File Offset: 0x00001190
	public virtual void Start()
	{
		this.viewCam = (aoi_character_pack_v0111_viewscript)GameObject.Find("Main Camera").GetComponent("aoi_character_pack_v0111_viewscript");
		this.faceMat_L = (Material)Resources.Load(this.materialsPath + "f02_face_l", typeof(Material));
		this.faceMat_M = (Material)Resources.Load(this.materialsPath + "f02_face_m", typeof(Material));
		this.txt = (TextAsset)Resources.Load(this.settingsPath + "/background_list", typeof(TextAsset));
		this.backGroundList = this.txt.text.Split(new string[]
		{
			"\r",
			"\n"
		}, StringSplitOptions.RemoveEmptyEntries);
		this.txt = (TextAsset)Resources.Load(this.settingsPath + "/" + this.FBXListFile, typeof(TextAsset));
		this.modelList = this.txt.text.Split(new string[]
		{
			"\r",
			"\n"
		}, StringSplitOptions.RemoveEmptyEntries);
		this.txt = (TextAsset)Resources.Load(this.settingsPath + "/" + this.AnimationListFile, typeof(TextAsset));
		this.animationList = this.txt.text.Split(new string[]
		{
			"\r",
			"\n"
		}, StringSplitOptions.RemoveEmptyEntries);
		this.txt = (TextAsset)Resources.Load(this.settingsPath + "/" + this.TitleTextFile, typeof(TextAsset));
		this.titleText = this.txt.text;
		this.txt = (TextAsset)Resources.Load(this.settingsPath + "/fbx_ctrl", typeof(TextAsset));
		this.xDoc = new XmlDocument();
		this.xDoc.LoadXml(this.txt.text);
		this.SetInitBackGround();
		this.SetInitModel();
		this.SetInitMotion();
		this.SetAnimationSpeed(this.animSpeed);
	}

	// Token: 0x06000011 RID: 17 RVA: 0x000031DC File Offset: 0x000013DC
	public virtual void Update()
	{
		if (Input.GetKeyDown("1"))
		{
			this.SetNextModel(-1);
		}
		if (Input.GetKeyDown("2"))
		{
			this.SetNextModel(-1);
		}
		if (Input.GetKeyDown("q"))
		{
			this.SetNextMotion(-1);
		}
		if (Input.GetKeyDown("w"))
		{
			this.SetNextMotion(1);
		}
		if (Input.GetKeyDown("a"))
		{
			this.SetNextBackGround(-1);
		}
		if (Input.GetKeyDown("s"))
		{
			this.SetNextBackGround(1);
		}
		if (Input.GetKeyDown("z"))
		{
			this.SetNextLOD(-1);
		}
		if (Input.GetKeyDown("x"))
		{
			this.SetNextLOD(1);
		}
	}

	// Token: 0x06000012 RID: 18 RVA: 0x0000329C File Offset: 0x0000149C
	public virtual void OnGUI()
	{
		if (this.guiOn)
		{
			if (this.guiSkin)
			{
				GUI.skin = this.guiSkin;
			}
			this.scale.x = (float)Screen.width / 960f;
			this.scale.y = (float)Screen.height / 600f;
			this.scale.x = (float)1;
			this.scale.y = (float)1;
			this.scale.z = 1f;
			GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, this.scale);
			GUI.Label(new Rect((float)20, (float)20, (float)500, (float)50), this.titleText, "Title");
			GUILayout.BeginArea(this.modelBodyRect);
			GUILayout.BeginVertical(new GUILayoutOption[0]);
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			if (GUILayout.Button(string.Empty, "Left", new GUILayoutOption[0]))
			{
				this.SetNextModel(-1);
			}
			GUILayout.Label(string.Empty, "Costume", new GUILayoutOption[0]);
			if (GUILayout.Button(string.Empty, "Right", new GUILayoutOption[0]))
			{
				this.SetNextModel(1);
			}
			GUILayout.EndHorizontal();
			GUILayout.Space((float)20);
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			if (GUILayout.Button(string.Empty, "Left", new GUILayoutOption[0]))
			{
				this.SetNextMotion(-1);
			}
			GUILayout.Label(string.Empty, "Anim", new GUILayoutOption[0]);
			if (GUILayout.Button(string.Empty, "Right", new GUILayoutOption[0]))
			{
				this.SetNextMotion(1);
			}
			GUILayout.EndHorizontal();
			GUILayout.Space((float)20);
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			if (GUILayout.Button(string.Empty, "Left", new GUILayoutOption[0]))
			{
				this.SetNextBackGround(-1);
			}
			GUILayout.Label(string.Empty, "BG", new GUILayoutOption[0]);
			if (GUILayout.Button(string.Empty, "Right", new GUILayoutOption[0]))
			{
				this.SetNextBackGround(1);
			}
			GUILayout.EndHorizontal();
			GUILayout.Space((float)20);
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			if (GUILayout.Button(string.Empty, "Left", new GUILayoutOption[0]))
			{
				this.SetNextLOD(-1);
			}
			GUILayout.Label(string.Empty, "LOD", new GUILayoutOption[0]);
			if (GUILayout.Button(string.Empty, "Right", new GUILayoutOption[0]))
			{
				this.SetNextLOD(1);
			}
			GUILayout.EndHorizontal();
			GUILayout.FlexibleSpace();
			GUILayout.EndVertical();
			GUILayout.EndArea();
			GUILayout.BeginArea(this.animSpeedGuiBodyRect);
			GUILayout.FlexibleSpace();
			float num = GUILayout.HorizontalSlider(this.animSpeed, (float)0, (float)2, new GUILayoutOption[0]);
			if (this.animSpeed != num)
			{
				this.animSpeed = num;
				this.SetAnimationSpeed(this.animSpeed);
				this.viewCam.MouseLock(true);
			}
			else
			{
				this.viewCam.MouseLock(false);
			}
			GUILayout.FlexibleSpace();
			string text = "Animation Speed : " + string.Format("{0:F1}", this.animSpeed);
			GUILayout.Box(text, new GUILayoutOption[0]);
			GUILayout.FlexibleSpace();
			GUILayout.EndArea();
			GUI.Label(this.camGuiRootRect, string.Empty, "CamBG");
			GUILayout.BeginArea(this.camGuiBodyRect);
			GUILayout.BeginHorizontal(new GUILayoutOption[0]);
			GUILayout.BeginVertical(new GUILayoutOption[0]);
			bool flag = default(bool);
			flag = GUILayout.Toggle(this.CamMode == 0, string.Empty, "Rote", new GUILayoutOption[0]);
			if (this.CamMode != 0 && flag)
			{
				this.CamMode = 0;
				this.viewCam.ModeRote();
			}
			GUILayout.FlexibleSpace();
			flag = GUILayout.Toggle(this.CamMode == 1, string.Empty, "Move", new GUILayoutOption[0]);
			if (this.CamMode != 1 && flag)
			{
				this.CamMode = 1;
				this.viewCam.ModeMove();
			}
			GUILayout.FlexibleSpace();
			flag = GUILayout.Toggle(this.CamMode == 2, string.Empty, "Zoom", new GUILayoutOption[0]);
			if (this.CamMode != 2 && flag)
			{
				this.CamMode = 2;
				this.viewCam.ModeZoom();
			}
			GUILayout.FlexibleSpace();
			flag = GUILayout.Toggle(this.CamModeFix, string.Empty, "Fix", new GUILayoutOption[0]);
			if (this.CamModeFix != flag)
			{
				this.CamModeFix = flag;
				this.viewCam.FixTarget(this.CamModeFix);
			}
			GUILayout.FlexibleSpace();
			if (GUILayout.Button(string.Empty, "Reset", new GUILayoutOption[0]))
			{
				this.viewCam.Reset();
			}
			GUILayout.FlexibleSpace();
			GUILayout.EndVertical();
			GUILayout.EndHorizontal();
			GUILayout.EndArea();
			string text2 = string.Empty;
			text2 += "Costume : " + (this.curModel + 1) + " / " + Extensions.get_length(this.modelList) + " : " + this.curModelName + "\n";
			text2 += "Animation : " + (this.curAnim + 1) + " / " + Extensions.get_length(this.animationList) + " : " + this.curAnimName + "\n";
			text2 += "BackGround : " + (this.curBG + 1) + " / " + Extensions.get_length(this.backGroundList) + " : " + this.curBgName + "\n";
			text2 += "Quality : " + this.lodTextList[(int)this.curLOD] + "\n";
			GUI.Box(this.textGuiBodyRect, text2);
		}
	}

	// Token: 0x06000013 RID: 19 RVA: 0x00003924 File Offset: 0x00001B24
	public virtual void SetInitModel()
	{
		this.curModel = 0;
		this.ModelChange(this.modelList[this.curModel] + this.lodList[(int)this.curLOD]);
	}

	// Token: 0x06000014 RID: 20 RVA: 0x00003954 File Offset: 0x00001B54
	public virtual void SetNextModel(int _add)
	{
		this.curModel += _add;
		if (this.modelList.Length <= this.curModel)
		{
			this.curModel = 0;
		}
		else if (this.curModel < 0)
		{
			this.curModel = this.modelList.Length - 1;
		}
		this.ModelChange(this.modelList[this.curModel] + this.lodList[(int)this.curLOD]);
	}

	// Token: 0x06000015 RID: 21 RVA: 0x000039D8 File Offset: 0x00001BD8
	public virtual void SetNextLOD(int _add)
	{
		this.curLOD += (float)_add;
		if ((float)this.lodList.Length <= this.curLOD)
		{
			this.curLOD = (float)0;
		}
		else if (this.curLOD < (float)0)
		{
			this.curLOD = (float)(this.lodList.Length - 1);
		}
		this.ModelChange(this.modelList[this.curModel] + this.lodList[(int)this.curLOD]);
	}

	// Token: 0x06000016 RID: 22 RVA: 0x00003A60 File Offset: 0x00001C60
	public virtual void ModelChange(string _name)
	{
		if (!string.IsNullOrEmpty(_name))
		{
			MonoBehaviour.print("ModelChange : " + _name);
			this.curModelName = Path.GetFileNameWithoutExtension(_name);
			GameObject original = (GameObject)Resources.Load(_name, typeof(GameObject));
			UnityEngine.Object.Destroy(this.obj);
			Debug.Log(_name);
			this.obj = (((GameObject)UnityEngine.Object.Instantiate(original)) as GameObject);
			this.SM = (((SkinnedMeshRenderer)this.obj.GetComponentInChildren(typeof(SkinnedMeshRenderer))) as SkinnedMeshRenderer);
			this.SM.quality = SkinQuality.Bone4;
			this.SM.updateWhenOffscreen = true;
			int num = 0;
			int i = 0;
			Material[] sharedMaterials = this.SM.renderer.sharedMaterials;
			int length = sharedMaterials.Length;
			while (i < length)
			{
				if (sharedMaterials[i].name == "face02_M")
				{
					this.SM.renderer.materials[num] = this.faceMat_M;
				}
				else if (sharedMaterials[i].name == "face02_L")
				{
					this.SM.renderer.materials[num] = this.faceMat_L;
				}
				num++;
				i++;
			}
			IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(this.animTest.animation);
			while (enumerator.MoveNext())
			{
				object obj = enumerator.Current;
				object obj3;
				object obj2 = obj3 = obj;
				if (!(obj2 is AnimationState))
				{
					obj3 = RuntimeServices.Coerce(obj2, typeof(AnimationState));
				}
				AnimationState animationState = (AnimationState)obj3;
				this.obj.animation.AddClip(animationState.clip, animationState.name);
				UnityRuntimeServices.Update(enumerator, animationState);
			}
			this.viewCam.ModelTarget(this.GetBone(this.obj, this.boneName));
			this.SetAnimation(string.Empty + this.animationList[this.curAnim]);
			this.SetAnimationSpeed(this.animSpeed);
		}
	}

	// Token: 0x06000017 RID: 23 RVA: 0x00003C64 File Offset: 0x00001E64
	public virtual void SetAnimationSpeed(float _speed)
	{
		IEnumerator enumerator = UnityRuntimeServices.GetEnumerator(this.obj.animation);
		while (enumerator.MoveNext())
		{
			object obj = enumerator.Current;
			object obj3;
			object obj2 = obj3 = obj;
			if (!(obj2 is AnimationState))
			{
				obj3 = RuntimeServices.Coerce(obj2, typeof(AnimationState));
			}
			AnimationState animationState = (AnimationState)obj3;
			animationState.speed = _speed;
			UnityRuntimeServices.Update(enumerator, animationState);
		}
	}

	// Token: 0x06000018 RID: 24 RVA: 0x00003CC8 File Offset: 0x00001EC8
	public virtual void SetInitMotion()
	{
		this.curAnim = 0;
		this.SetAnimation(this.animationList[this.curAnim]);
		this.SetAnimationSpeed(this.animSpeed);
	}

	// Token: 0x06000019 RID: 25 RVA: 0x00003CFC File Offset: 0x00001EFC
	public virtual void SetNextMotion(int _add)
	{
		this.curAnim += _add;
		if (Extensions.get_length(this.animationList) <= this.curAnim)
		{
			this.curAnim = 0;
		}
		else if (this.curAnim < 0)
		{
			this.curAnim = Extensions.get_length(this.animationList) - 1;
		}
		this.SetAnimation(this.animationList[this.curAnim]);
		this.SetAnimationSpeed(this.animSpeed);
	}

	// Token: 0x0600001A RID: 26 RVA: 0x00003D78 File Offset: 0x00001F78
	public virtual void SetAnimation(string _name)
	{
		if (!string.IsNullOrEmpty(_name))
		{
			MonoBehaviour.print("SetAnimation : " + _name);
			this.curAnimName = string.Empty + _name;
			this.obj.animation.Play(this.curAnimName);
			this.SetFixedFbx(this.xDoc, this.obj, this.curModelName, this.curAnimName, (int)this.curLOD);
		}
	}

	// Token: 0x0600001B RID: 27 RVA: 0x00003DF0 File Offset: 0x00001FF0
	public virtual void SetInitBackGround()
	{
		this.curBG = 0;
		this.SetBackGround(this.backGroundList[this.curBG]);
	}

	// Token: 0x0600001C RID: 28 RVA: 0x00003E0C File Offset: 0x0000200C
	public virtual void SetNextBackGround(int _add)
	{
		this.curBG += _add;
		if (Extensions.get_length(this.backGroundList) <= this.curBG)
		{
			this.curBG = 0;
		}
		else if (this.curBG < 0)
		{
			this.curBG = Extensions.get_length(this.backGroundList) - 1;
		}
		this.SetBackGround(this.backGroundList[this.curBG]);
	}

	// Token: 0x0600001D RID: 29 RVA: 0x00003E7C File Offset: 0x0000207C
	public virtual void SetBackGround(string _name)
	{
		if (!string.IsNullOrEmpty(_name))
		{
			MonoBehaviour.print("SetBackGround : " + _name);
			this.curBgName = Path.GetFileNameWithoutExtension(_name);
			Texture2D mainTexture = (Texture2D)Resources.Load(_name, typeof(Texture2D));
			GameObject gameObject = GameObject.Find("BillBoard") as GameObject;
			gameObject.renderer.material.mainTexture = mainTexture;
		}
	}

	// Token: 0x0600001E RID: 30 RVA: 0x00003EE8 File Offset: 0x000020E8
	public virtual Transform GetBone(GameObject _obj, string _bone)
	{
		SkinnedMeshRenderer skinnedMeshRenderer = ((SkinnedMeshRenderer)_obj.GetComponentInChildren(typeof(SkinnedMeshRenderer))) as SkinnedMeshRenderer;
		if (skinnedMeshRenderer)
		{
			int i = 0;
			Transform[] bones = skinnedMeshRenderer.bones;
			int length = bones.Length;
			while (i < length)
			{
				if (bones[i].name == _bone)
				{
					return bones[i];
				}
				i++;
			}
		}
		return null;
	}

	// Token: 0x0600001F RID: 31 RVA: 0x00003F5C File Offset: 0x0000215C
	public virtual void SetFixedFbx(XmlDocument _xDoc, GameObject _obj, string _model, string _anim, int _lod)
	{
		if (!RuntimeServices.EqualityOperator(_xDoc, null))
		{
			if (!(_obj == null))
			{
				string xpath = "Root/Texture[@Lod=''or@Lod='" + _lod + "'][Info[@Model=''or@Model='" + _model + "'][@Ani=''or@Ani='" + _anim + "']]";
				XmlNode xmlNode = _xDoc.SelectSingleNode(xpath);
				if (xmlNode != null)
				{
					string innerText = xmlNode.Attributes["Material"].InnerText;
					string innerText2 = xmlNode.Attributes["Property"].InnerText;
					string innerText3 = xmlNode.Attributes["File"].InnerText;
					MonoBehaviour.print("Change Texture To " + innerText + " : " + innerText2 + " : " + innerText3);
					int i = 0;
					Material[] sharedMaterials = this.SM.renderer.sharedMaterials;
					int length = sharedMaterials.Length;
					while (i < length)
					{
						if (sharedMaterials[i] && sharedMaterials[i].name == innerText)
						{
							Texture2D texture = (Texture2D)Resources.Load(innerText3, typeof(Texture2D));
							sharedMaterials[i].SetTexture(innerText2, texture);
						}
						i++;
					}
				}
				xpath = "Root/Animation[@Lod=''or@Lod='" + _lod + "'][Info[@Model=''or@Model='" + _model + "'][@Ani=''or@Ani='" + _anim + "']]";
				XmlNode xmlNode2 = _xDoc.SelectSingleNode(xpath);
				if (xmlNode2 != null)
				{
					string innerText4 = xmlNode2.Attributes["File"].InnerText;
					this.curAnimName = innerText4;
					MonoBehaviour.print("Change Animation To " + this.curAnimName);
					_obj.animation.Play(this.curAnimName);
				}
			}
		}
	}

	// Token: 0x06000020 RID: 32 RVA: 0x00004170 File Offset: 0x00002370
	public virtual void Main()
	{
	}

	// Token: 0x0400002F RID: 47
	public GameObject animTest;

	// Token: 0x04000030 RID: 48
	public aoi_character_pack_v0111_viewscript viewCam;

	// Token: 0x04000031 RID: 49
	public GUISkin guiSkin;

	// Token: 0x04000032 RID: 50
	public string boneName;

	// Token: 0x04000033 RID: 51
	public Rect camGuiRootRect;

	// Token: 0x04000034 RID: 52
	public Rect camGuiBodyRect;

	// Token: 0x04000035 RID: 53
	public Rect animSpeedGuiBodyRect;

	// Token: 0x04000036 RID: 54
	public Rect textGuiBodyRect;

	// Token: 0x04000037 RID: 55
	public Rect modelBodyRect;

	// Token: 0x04000038 RID: 56
	public string FBXListFile;

	// Token: 0x04000039 RID: 57
	public string AnimationListFile;

	// Token: 0x0400003A RID: 58
	public string TitleTextFile;

	// Token: 0x0400003B RID: 59
	public bool guiOn;

	// Token: 0x0400003C RID: 60
	private string viewerResourcesPath;

	// Token: 0x0400003D RID: 61
	private string settingsPath;

	// Token: 0x0400003E RID: 62
	private string materialsPath;

	// Token: 0x0400003F RID: 63
	private int curBG;

	// Token: 0x04000040 RID: 64
	private int curAnim;

	// Token: 0x04000041 RID: 65
	private int curModel;

	// Token: 0x04000042 RID: 66
	private float curLOD;

	// Token: 0x04000043 RID: 67
	private string curModelName;

	// Token: 0x04000044 RID: 68
	private string curAnimName;

	// Token: 0x04000045 RID: 69
	private string curBgName;

	// Token: 0x04000046 RID: 70
	private float animSpeed;

	// Token: 0x04000047 RID: 71
	private string[] animationList;

	// Token: 0x04000048 RID: 72
	private string[] modelList;

	// Token: 0x04000049 RID: 73
	private string[] backGroundList;

	// Token: 0x0400004A RID: 74
	private string[] lodList;

	// Token: 0x0400004B RID: 75
	private string[] lodTextList;

	// Token: 0x0400004C RID: 76
	private GameObject obj;

	// Token: 0x0400004D RID: 77
	private GameObject loaded;

	// Token: 0x0400004E RID: 78
	private SkinnedMeshRenderer SM;

	// Token: 0x0400004F RID: 79
	private TextAsset txt;

	// Token: 0x04000050 RID: 80
	private bool CamModeRote;

	// Token: 0x04000051 RID: 81
	private bool CamModeMove;

	// Token: 0x04000052 RID: 82
	private bool CamModeZoom;

	// Token: 0x04000053 RID: 83
	private bool CamModeFix;

	// Token: 0x04000054 RID: 84
	private int CamMode;

	// Token: 0x04000055 RID: 85
	private string titleText;

	// Token: 0x04000056 RID: 86
	private XmlDocument xDoc;

	// Token: 0x04000057 RID: 87
	private XmlNodeList xNodeList;

	// Token: 0x04000058 RID: 88
	private Material faceMat_L;

	// Token: 0x04000059 RID: 89
	private Material faceMat_M;

	// Token: 0x0400005A RID: 90
	private Vector3 scale;
}
