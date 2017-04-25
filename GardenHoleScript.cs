using System;
using UnityEngine;
using UnityScript.Lang;

// Token: 0x0200009A RID: 154
[Serializable]
public class GardenHoleScript : MonoBehaviour
{
	// Token: 0x06000380 RID: 896 RVA: 0x00047CC0 File Offset: 0x00045EC0
	public virtual void Start()
	{
		if (PlayerPrefs.GetInt("GardenGrave_" + this.ID + "_Occupied") == 1)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			this.enabled = false;
		}
	}

	// Token: 0x06000381 RID: 897 RVA: 0x00047D1C File Offset: 0x00045F1C
	public virtual void Update()
	{
		if (this.Yandere.transform.position.z < this.transform.position.z - 0.5f)
		{
			if (this.Yandere.Equipped > 0)
			{
				if (this.Yandere.Weapon[this.Yandere.Equipped].WeaponID == 10)
				{
					this.Prompt.enabled = true;
				}
				else if (this.Prompt.enabled)
				{
					this.Prompt.Hide();
					this.Prompt.enabled = false;
				}
			}
			else if (this.Prompt.enabled)
			{
				this.Prompt.Hide();
				this.Prompt.enabled = false;
			}
		}
		else if (this.Prompt.enabled)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
		if (this.Prompt.Circle[0].fillAmount == (float)0)
		{
			for (int i = 0; i < Extensions.get_length(this.Yandere.ArmedAnims); i++)
			{
				this.Yandere.CharacterAnimation[this.Yandere.ArmedAnims[i]].weight = (float)0;
			}
			this.Yandere.transform.rotation = Quaternion.LookRotation(new Vector3(this.transform.position.x, this.Yandere.transform.position.y, this.transform.position.z) - this.Yandere.transform.position);
			this.Yandere.RPGCamera.transform.eulerAngles = this.Yandere.DigSpot.eulerAngles;
			this.Yandere.RPGCamera.transform.position = this.Yandere.DigSpot.position;
			this.Yandere.Weapon[this.Yandere.Equipped].gameObject.active = false;
			this.Yandere.CharacterAnimation["f02_shovelBury_00"].time = (float)0;
			this.Yandere.CharacterAnimation["f02_shovelDig_00"].time = (float)0;
			this.Yandere.FloatingShovel.active = true;
			this.Yandere.RPGCamera.enabled = false;
			this.Yandere.CanMove = false;
			this.Yandere.DigPhase = 1;
			this.Prompt.Circle[0].fillAmount = (float)1;
			if (!this.Dug)
			{
				this.Yandere.FloatingShovel.animation["Dig"].time = (float)0;
				this.Yandere.FloatingShovel.animation.Play("Dig");
				this.Yandere.Character.animation.Play("f02_shovelDig_00");
				this.Yandere.Digging = true;
				this.Prompt.Label[0].text = "     " + "Fill";
				this.MyCollider.isTrigger = true;
				this.MyMesh.mesh = this.HoleMesh;
				this.Pile.active = true;
				this.Dug = true;
			}
			else
			{
				this.Yandere.FloatingShovel.animation["Bury"].time = (float)0;
				this.Yandere.FloatingShovel.animation.Play("Bury");
				this.Yandere.Character.animation.Play("f02_shovelBury_00");
				this.Yandere.Burying = true;
				this.Prompt.Label[0].text = "     " + "Dig";
				this.MyCollider.isTrigger = false;
				this.MyMesh.mesh = this.MoundMesh;
				this.Pile.active = false;
				this.Dug = false;
			}
			if (this.Bury)
			{
				this.Yandere.Police.Corpses = this.Yandere.Police.Corpses - 1;
				if (this.Yandere.Police.SuicideScene && this.Yandere.Police.Corpses == 1)
				{
					this.Yandere.Police.MurderScene = false;
				}
				if (this.Yandere.Police.Corpses == 0)
				{
					this.Yandere.Police.MurderScene = false;
				}
				this.VictimID = this.Corpse.StudentID;
				this.Corpse.Remove();
				PlayerPrefs.SetInt("GardenGrave_" + this.ID + "_Occupied", 1);
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				this.enabled = false;
			}
		}
	}

	// Token: 0x06000382 RID: 898 RVA: 0x00048250 File Offset: 0x00046450
	public virtual void OnTriggerEnter(Collider other)
	{
		if (this.Dug && other.gameObject.layer == 11)
		{
			this.Prompt.Label[0].text = "     " + "Bury";
			this.Corpse = (RagdollScript)other.transform.root.gameObject.GetComponent(typeof(RagdollScript));
			this.Bury = true;
		}
	}

	// Token: 0x06000383 RID: 899 RVA: 0x000482D0 File Offset: 0x000464D0
	public virtual void OnTriggerExit(Collider other)
	{
		if (this.Dug && other.gameObject.layer == 11)
		{
			this.Prompt.Label[0].text = "     " + "Fill";
			this.Corpse = null;
			this.Bury = false;
		}
	}

	// Token: 0x06000384 RID: 900 RVA: 0x0004832C File Offset: 0x0004652C
	public virtual void Main()
	{
	}

	// Token: 0x040008BD RID: 2237
	public YandereScript Yandere;

	// Token: 0x040008BE RID: 2238
	public RagdollScript Corpse;

	// Token: 0x040008BF RID: 2239
	public PromptScript Prompt;

	// Token: 0x040008C0 RID: 2240
	public Collider MyCollider;

	// Token: 0x040008C1 RID: 2241
	public MeshFilter MyMesh;

	// Token: 0x040008C2 RID: 2242
	public GameObject Pile;

	// Token: 0x040008C3 RID: 2243
	public Mesh MoundMesh;

	// Token: 0x040008C4 RID: 2244
	public Mesh HoleMesh;

	// Token: 0x040008C5 RID: 2245
	public bool Bury;

	// Token: 0x040008C6 RID: 2246
	public bool Dug;

	// Token: 0x040008C7 RID: 2247
	public int VictimID;

	// Token: 0x040008C8 RID: 2248
	public int ID;
}
