using System;
using UnityEngine;

// Token: 0x02000042 RID: 66
[Serializable]
public class ArmDetectorScript : MonoBehaviour
{
	// Token: 0x060001D7 RID: 471 RVA: 0x00021C40 File Offset: 0x0001FE40
	public ArmDetectorScript()
	{
		this.Phase = 1;
	}

	// Token: 0x060001D8 RID: 472 RVA: 0x00021C50 File Offset: 0x0001FE50
	public virtual void Start()
	{
		this.DemonDress.active = false;
	}

	// Token: 0x060001D9 RID: 473 RVA: 0x00021C60 File Offset: 0x0001FE60
	public virtual void Update()
	{
		if (!this.SummonDemon)
		{
			for (int i = 1; i < this.ArmArray.Length; i++)
			{
				if (this.ArmArray[i] != null && this.ArmArray[i].transform.parent != null)
				{
					this.ArmArray[i] = null;
					if (i != this.ArmArray.Length - 1)
					{
						this.Shuffle(i);
					}
					this.Arms--;
				}
			}
			if (this.Arms > 9)
			{
				this.Yandere.Character.animation.CrossFade(this.Yandere.IdleAnim);
				this.Yandere.CanMove = false;
				this.SummonDemon = true;
				this.audio.Play();
				this.Arms = 0;
			}
		}
		if (!this.SummonFlameDemon)
		{
			this.CorpsesCounted = 0;
			this.Sacrifices = 0;
			int i = 0;
			while (this.CorpsesCounted < this.Police.Corpses)
			{
				if (this.Police.CorpseList[i] != null)
				{
					this.CorpsesCounted++;
					if (this.Police.CorpseList[i].Burned && this.Police.CorpseList[i].Sacrifice && !this.Police.CorpseList[i].Dragged && !this.Police.CorpseList[i].Carried)
					{
						this.Sacrifices++;
					}
				}
				i++;
			}
			if (this.Sacrifices > 4)
			{
				this.Yandere.Character.animation.CrossFade(this.Yandere.IdleAnim);
				this.Yandere.CanMove = false;
				this.SummonFlameDemon = true;
				this.audio.Play();
			}
		}
		if (this.SummonDemon)
		{
			if (this.Phase == 1)
			{
				if (this.ArmArray[1] != null)
				{
					for (int i = 1; i < 11; i++)
					{
						if (this.ArmArray[i] != null)
						{
							UnityEngine.Object.Instantiate(this.SmallDarkAura, this.ArmArray[i].transform.position, Quaternion.identity);
							UnityEngine.Object.Destroy(this.ArmArray[i]);
						}
					}
				}
				this.Timer += Time.deltaTime;
				if (this.Timer > (float)1)
				{
					this.Timer = (float)0;
					this.Phase++;
				}
			}
			else if (this.Phase == 2)
			{
				float a = Mathf.MoveTowards(this.Darkness.color.a, (float)1, Time.deltaTime);
				Color color = this.Darkness.color;
				float num = color.a = a;
				Color color2 = this.Darkness.color = color;
				this.Jukebox.Volume = Mathf.MoveTowards(this.Jukebox.Volume, (float)0, Time.deltaTime);
				if (this.Darkness.color.a == (float)1)
				{
					PlayerPrefs.SetFloat("SchoolAtmosphere", (float)0);
					this.StudentManager.SetAtmosphere();
					this.Yandere.transform.eulerAngles = new Vector3((float)0, (float)180, (float)0);
					this.Yandere.transform.position = new Vector3((float)12, 0.1f, (float)26);
					this.DemonSubtitle.text = "...revenge...at last...";
					this.BloodProjector.active = true;
					int num2 = 0;
					Color color3 = this.DemonSubtitle.color;
					float num3 = color3.a = (float)num2;
					Color color4 = this.DemonSubtitle.color = color3;
					this.Skull.Prompt.Hide();
					this.Skull.Prompt.enabled = false;
					this.Skull.enabled = false;
					this.audio.clip = this.DemonLine;
					this.audio.Play();
					this.Phase++;
				}
			}
			else if (this.Phase == 3)
			{
				this.DemonSubtitle.transform.localPosition = new Vector3(UnityEngine.Random.Range(-10f, 10f), UnityEngine.Random.Range(-10f, 10f), UnityEngine.Random.Range(-10f, 10f));
				float a2 = Mathf.MoveTowards(this.DemonSubtitle.color.a, (float)1, Time.deltaTime);
				Color color5 = this.DemonSubtitle.color;
				float num4 = color5.a = a2;
				Color color6 = this.DemonSubtitle.color = color5;
				if (this.DemonSubtitle.color.a == (float)1 && Input.GetButtonDown("A"))
				{
					this.Phase++;
				}
			}
			else if (this.Phase == 4)
			{
				this.DemonSubtitle.transform.localPosition = new Vector3(UnityEngine.Random.Range(-10f, 10f), UnityEngine.Random.Range(-10f, 10f), UnityEngine.Random.Range(-10f, 10f));
				float a3 = Mathf.MoveTowards(this.DemonSubtitle.color.a, (float)0, Time.deltaTime);
				Color color7 = this.DemonSubtitle.color;
				float num5 = color7.a = a3;
				Color color8 = this.DemonSubtitle.color = color7;
				if (this.DemonSubtitle.color.a == (float)0)
				{
					this.audio.clip = this.DemonMusic;
					this.audio.loop = true;
					this.audio.Play();
					this.DemonSubtitle.text = string.Empty;
					this.Phase++;
				}
			}
			else if (this.Phase == 5)
			{
				float a4 = Mathf.MoveTowards(this.Darkness.color.a, (float)0, Time.deltaTime);
				Color color9 = this.Darkness.color;
				float num6 = color9.a = a4;
				Color color10 = this.Darkness.color = color9;
				if (this.Darkness.color.a == (float)0)
				{
					this.Yandere.Character.animation.CrossFade("f02_demonSummon_00");
					this.Phase++;
				}
			}
			else if (this.Phase == 6)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer > (float)this.ArmsSpawned)
				{
					GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this.DemonArm, this.SpawnPoints[this.ArmsSpawned].position, Quaternion.identity);
					gameObject.transform.parent = this.Yandere.transform;
					gameObject.transform.LookAt(this.Yandere.transform);
					float y = gameObject.transform.localEulerAngles.y + (float)180;
					Vector3 localEulerAngles = gameObject.transform.localEulerAngles;
					float num7 = localEulerAngles.y = y;
					Vector3 vector = gameObject.transform.localEulerAngles = localEulerAngles;
					this.ArmsSpawned++;
					if (this.ArmsSpawned % 2 == 1)
					{
						((DemonArmScript)gameObject.GetComponent(typeof(DemonArmScript))).IdleAnim = "DemonArmIdleOld";
					}
					else
					{
						((DemonArmScript)gameObject.GetComponent(typeof(DemonArmScript))).IdleAnim = "DemonArmIdle";
					}
				}
				if (this.ArmsSpawned == 10)
				{
					this.Yandere.CanMove = true;
					this.Yandere.IdleAnim = "f02_demonIdle_00";
					this.Yandere.WalkAnim = "f02_demonWalk_00";
					this.Yandere.RunAnim = "f02_demonRun_00";
					this.Yandere.Demonic = true;
					this.SummonDemon = false;
				}
			}
		}
		if (this.SummonFlameDemon)
		{
			if (this.Phase == 1)
			{
				for (int i = 0; i < this.Police.CorpseList.Length; i++)
				{
					if (this.Police.CorpseList[i] != null && this.Police.CorpseList[i].Burned && this.Police.CorpseList[i].Sacrifice && !this.Police.CorpseList[i].Dragged && !this.Police.CorpseList[i].Carried)
					{
						UnityEngine.Object.Instantiate(this.SmallDarkAura, this.Police.CorpseList[i].Prompt.transform.position, Quaternion.identity);
						UnityEngine.Object.Destroy(this.Police.CorpseList[i].gameObject);
						this.Yandere.NearBodies = this.Yandere.NearBodies - 1;
						this.Police.Corpses = this.Police.Corpses - 1;
					}
				}
				this.Phase++;
			}
			else if (this.Phase == 2)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer > (float)1)
				{
					this.Timer = (float)0;
					this.Phase++;
				}
			}
			else if (this.Phase == 3)
			{
				float a5 = Mathf.MoveTowards(this.Darkness.color.a, (float)1, Time.deltaTime);
				Color color11 = this.Darkness.color;
				float num8 = color11.a = a5;
				Color color12 = this.Darkness.color = color11;
				this.Jukebox.Volume = Mathf.MoveTowards(this.Jukebox.Volume, (float)0, Time.deltaTime);
				if (this.Darkness.color.a == (float)1)
				{
					this.Yandere.transform.eulerAngles = new Vector3((float)0, (float)180, (float)0);
					this.Yandere.transform.position = new Vector3((float)12, 0.1f, (float)26);
					this.DemonSubtitle.text = "You have proven your worth. Very well. I shall lend you my power.";
					this.DemonSubtitle.color = new Color((float)1, (float)0, (float)0, (float)0);
					this.Skull.Prompt.Hide();
					this.Skull.Prompt.enabled = false;
					this.Skull.enabled = false;
					this.audio.clip = this.FlameDemonLine;
					this.audio.Play();
					this.Phase++;
				}
			}
			else if (this.Phase == 4)
			{
				this.DemonSubtitle.transform.localPosition = new Vector3(UnityEngine.Random.Range(-5f, 5f), UnityEngine.Random.Range(-5f, 5f), UnityEngine.Random.Range(-5f, 5f));
				float a6 = Mathf.MoveTowards(this.DemonSubtitle.color.a, (float)1, Time.deltaTime);
				Color color13 = this.DemonSubtitle.color;
				float num9 = color13.a = a6;
				Color color14 = this.DemonSubtitle.color = color13;
				if (this.DemonSubtitle.color.a == (float)1 && Input.GetButtonDown("A"))
				{
					this.Phase++;
				}
			}
			else if (this.Phase == 5)
			{
				this.DemonSubtitle.transform.localPosition = new Vector3(UnityEngine.Random.Range((float)-10, 10f), UnityEngine.Random.Range((float)-10, 10f), UnityEngine.Random.Range((float)-10, 10f));
				float a7 = Mathf.MoveTowards(this.DemonSubtitle.color.a, (float)0, Time.deltaTime);
				Color color15 = this.DemonSubtitle.color;
				float num10 = color15.a = a7;
				Color color16 = this.DemonSubtitle.color = color15;
				if (this.DemonSubtitle.color.a == (float)0)
				{
					this.DemonDress.active = true;
					this.Yandere.MyRenderer.sharedMesh = this.FlameDemonMesh;
					this.RiggedAccessory.active = true;
					this.Yandere.FlameDemonic = true;
					this.Yandere.Crouching = false;
					this.Yandere.Crawling = false;
					this.Yandere.Sanity = (float)100;
					this.Yandere.UpdateSanity();
					this.Yandere.MyRenderer.materials[0].mainTexture = this.Yandere.FaceTexture;
					this.Yandere.MyRenderer.materials[1].mainTexture = this.Yandere.NudePanties;
					this.Yandere.MyRenderer.materials[2].mainTexture = this.Yandere.NudePanties;
					this.DebugMenu.UpdateCensor();
					this.audio.clip = this.DemonMusic;
					this.audio.loop = true;
					this.audio.Play();
					this.DemonSubtitle.text = string.Empty;
					this.Phase++;
				}
			}
			else if (this.Phase == 6)
			{
				float a8 = Mathf.MoveTowards(this.Darkness.color.a, (float)0, Time.deltaTime);
				Color color17 = this.Darkness.color;
				float num11 = color17.a = a8;
				Color color18 = this.Darkness.color = color17;
				if (this.Darkness.color.a == (float)0)
				{
					this.Yandere.Character.animation.CrossFade("f02_demonSummon_00");
					this.Phase++;
				}
			}
			else if (this.Phase == 7)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer > (float)5)
				{
					this.audio.PlayOneShot(this.FlameActivate);
					this.RightFlame.active = true;
					this.LeftFlame.active = true;
					this.Phase++;
				}
			}
			else if (this.Phase == 8)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer > (float)10)
				{
					this.Yandere.CanMove = true;
					this.Yandere.IdleAnim = "f02_demonIdle_00";
					this.Yandere.WalkAnim = "f02_demonWalk_00";
					this.Yandere.RunAnim = "f02_demonRun_00";
					this.SummonFlameDemon = false;
				}
			}
		}
	}

	// Token: 0x060001DA RID: 474 RVA: 0x00022BF4 File Offset: 0x00020DF4
	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.transform.parent == null && (PickUpScript)other.gameObject.GetComponent(typeof(PickUpScript)) != null && ((PickUpScript)other.gameObject.GetComponent(typeof(PickUpScript))).BodyPart && ((BodyPartScript)other.gameObject.GetComponent(typeof(BodyPartScript))).Sacrifice && (other.gameObject.name == "FemaleRightArm(Clone)" || other.gameObject.name == "FemaleLeftArm(Clone)" || other.gameObject.name == "MaleRightArm(Clone)" || other.gameObject.name == "MaleLeftArm(Clone)" || other.gameObject.name == "SacrificialArm(Clone)"))
		{
			bool flag = true;
			for (int i = 1; i < 11; i++)
			{
				if (this.ArmArray[i] == other.gameObject)
				{
					flag = false;
				}
			}
			if (flag)
			{
				this.Arms++;
				this.ArmArray[this.Arms] = other.gameObject;
			}
		}
	}

	// Token: 0x060001DB RID: 475 RVA: 0x00022D60 File Offset: 0x00020F60
	public virtual void OnTriggerExit(Collider other)
	{
		if ((PickUpScript)other.gameObject.GetComponent(typeof(PickUpScript)) != null && ((PickUpScript)other.gameObject.GetComponent(typeof(PickUpScript))).BodyPart && ((BodyPartScript)other.gameObject.GetComponent(typeof(BodyPartScript))).Sacrifice && (other.gameObject.name == "FemaleRightArm(Clone)" || other.gameObject.name == "FemaleLeftArm(Clone)" || other.gameObject.name == "MaleRightArm(Clone)" || other.gameObject.name == "MaleLeftArm(Clone)" || other.gameObject.name == "SacrificialArm(Clone)"))
		{
			this.Arms--;
		}
	}

	// Token: 0x060001DC RID: 476 RVA: 0x00022E6C File Offset: 0x0002106C
	public virtual void Shuffle(int Start)
	{
		for (int i = Start; i < this.ArmArray.Length - 1; i++)
		{
			this.ArmArray[i] = this.ArmArray[i + 1];
		}
	}

	// Token: 0x060001DD RID: 477 RVA: 0x00022EAC File Offset: 0x000210AC
	public virtual void Main()
	{
	}

	// Token: 0x040003EA RID: 1002
	public StudentManagerScript StudentManager;

	// Token: 0x040003EB RID: 1003
	public DebugMenuScript DebugMenu;

	// Token: 0x040003EC RID: 1004
	public JukeboxScript Jukebox;

	// Token: 0x040003ED RID: 1005
	public YandereScript Yandere;

	// Token: 0x040003EE RID: 1006
	public PoliceScript Police;

	// Token: 0x040003EF RID: 1007
	public SkullScript Skull;

	// Token: 0x040003F0 RID: 1008
	public UILabel DemonSubtitle;

	// Token: 0x040003F1 RID: 1009
	public UISprite Darkness;

	// Token: 0x040003F2 RID: 1010
	public Transform[] SpawnPoints;

	// Token: 0x040003F3 RID: 1011
	public GameObject[] ArmArray;

	// Token: 0x040003F4 RID: 1012
	public GameObject RiggedAccessory;

	// Token: 0x040003F5 RID: 1013
	public GameObject BloodProjector;

	// Token: 0x040003F6 RID: 1014
	public GameObject SmallDarkAura;

	// Token: 0x040003F7 RID: 1015
	public GameObject DemonDress;

	// Token: 0x040003F8 RID: 1016
	public GameObject RightFlame;

	// Token: 0x040003F9 RID: 1017
	public GameObject LeftFlame;

	// Token: 0x040003FA RID: 1018
	public GameObject DemonArm;

	// Token: 0x040003FB RID: 1019
	public bool SummonFlameDemon;

	// Token: 0x040003FC RID: 1020
	public bool SummonDemon;

	// Token: 0x040003FD RID: 1021
	public Mesh FlameDemonMesh;

	// Token: 0x040003FE RID: 1022
	public int CorpsesCounted;

	// Token: 0x040003FF RID: 1023
	public int ArmsSpawned;

	// Token: 0x04000400 RID: 1024
	public int Sacrifices;

	// Token: 0x04000401 RID: 1025
	public int Phase;

	// Token: 0x04000402 RID: 1026
	public int Arms;

	// Token: 0x04000403 RID: 1027
	public float Timer;

	// Token: 0x04000404 RID: 1028
	public AudioClip FlameDemonLine;

	// Token: 0x04000405 RID: 1029
	public AudioClip FlameActivate;

	// Token: 0x04000406 RID: 1030
	public AudioClip DemonMusic;

	// Token: 0x04000407 RID: 1031
	public AudioClip DemonLine;
}
