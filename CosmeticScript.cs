using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;
using UnityScript.Lang;

// Token: 0x0200006D RID: 109
[Serializable]
public class CosmeticScript : MonoBehaviour
{
	// Token: 0x060002AB RID: 683 RVA: 0x0003233C File Offset: 0x0003053C
	public CosmeticScript()
	{
		this.HairColor = string.Empty;
		this.Stockings = string.Empty;
		this.EyeColor = string.Empty;
	}

	// Token: 0x060002AC RID: 684 RVA: 0x00032368 File Offset: 0x00030568
	public virtual void Start()
	{
		if (this.Kidnapped)
		{
			this.GanguroCasualTextures = this.GanguroUniformTextures;
			this.GanguroSocksTextures = this.GanguroUniformTextures;
			this.OccultCasualTextures = this.OccultUniformTextures;
			this.OccultSocksTextures = this.OccultUniformTextures;
			this.FemaleCasualTextures = this.FemaleUniformTextures;
			this.FemaleSocksTextures = this.FemaleUniformTextures;
		}
		if (this.RightShoe != null)
		{
			this.RightShoe.active = false;
			this.LeftShoe.active = false;
		}
		this.ColorValue = new Color((float)1, (float)1, (float)1, (float)1);
		if (this.JSON == null)
		{
			this.JSON = this.Student.JSON;
		}
		string text;
		if (!this.Initialized)
		{
			this.Accessory = UnityBuiltins.parseInt(this.JSON.StudentAccessories[this.StudentID]);
			this.Hairstyle = UnityBuiltins.parseInt(this.JSON.StudentHairstyles[this.StudentID]);
			this.Stockings = this.JSON.StudentStockings[this.StudentID];
			this.BreastSize = this.JSON.StudentBreasts[this.StudentID];
			this.HairColor = this.JSON.StudentColors[this.StudentID];
			this.EyeColor = this.JSON.StudentEyes[this.StudentID];
			this.Club = this.JSON.StudentClubs[this.StudentID];
			text = this.JSON.StudentNames[this.StudentID];
			this.Initialized = true;
		}
		if (text == "Random")
		{
			this.Randomize = true;
			if (!this.Male)
			{
				text = string.Empty + this.StudentManager.FirstNames[UnityEngine.Random.Range(0, Extensions.get_length(this.StudentManager.FirstNames))] + " " + this.StudentManager.LastNames[UnityEngine.Random.Range(0, Extensions.get_length(this.StudentManager.LastNames))];
				this.JSON.StudentNames[this.StudentID] = text;
				this.Student.Name = text;
			}
			else
			{
				text = string.Empty + this.StudentManager.MaleNames[UnityEngine.Random.Range(0, Extensions.get_length(this.StudentManager.MaleNames))] + " " + this.StudentManager.LastNames[UnityEngine.Random.Range(0, Extensions.get_length(this.StudentManager.LastNames))];
				this.JSON.StudentNames[this.StudentID] = text;
				this.Student.Name = text;
			}
			if (PlayerPrefs.GetInt("MissionMode") == 1 && PlayerPrefs.GetInt("MissionTarget") == this.StudentID)
			{
				this.JSON.StudentNames[this.StudentID] = PlayerPrefs.GetString("MissionTargetName");
				this.Student.Name = PlayerPrefs.GetString("MissionTargetName");
				text = PlayerPrefs.GetString("MissionTargetName");
			}
		}
		if (this.Randomize)
		{
			this.Teacher = false;
			this.BreastSize = UnityEngine.Random.Range(0.5f, 2f);
			this.Accessory = 0;
			this.Club = 0;
			if (!this.Male)
			{
				this.Hairstyle = UnityEngine.Random.Range(1, Extensions.get_length(this.FemaleHair) - 1);
			}
			else
			{
				this.SkinColor = UnityEngine.Random.Range(0, Extensions.get_length(this.SkinTextures));
				this.Hairstyle = UnityEngine.Random.Range(1, Extensions.get_length(this.MaleHair));
			}
		}
		if (!this.Male)
		{
			this.RightBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
			this.LeftBreast.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
			if (this.StudentID == 32 && !this.Kidnapped && Application.loadedLevelName == "PortraitScene")
			{
				this.Character.animation.Play("f02_socialCameraPose_00");
			}
		}
		else
		{
			for (int i = 0; i < Extensions.get_length(this.GaloAccessories); i++)
			{
				this.GaloAccessories[i].active = false;
			}
			if (this.Club == 3)
			{
				this.Character.animation["sadFace_00"].layer = 1;
				this.Character.animation.Play("sadFace_00");
				this.Character.animation["sadFace_00"].weight = (float)1;
			}
			if (this.StudentID == 13 && PlayerPrefs.GetInt("CustomSuitor") == 1)
			{
				if (PlayerPrefs.GetInt("CustomSuitorHair") > 0)
				{
					this.Hairstyle = PlayerPrefs.GetInt("CustomSuitorHair");
				}
				if (PlayerPrefs.GetInt("CustomSuitorAccessory") > 0)
				{
					this.Accessory = PlayerPrefs.GetInt("CustomSuitorAccessory");
					if (this.Accessory == 1)
					{
						float x = 1.02f;
						Vector3 localScale = this.MaleAccessories[1].transform.localScale;
						float num = localScale.x = x;
						Vector3 vector = this.MaleAccessories[1].transform.localScale = localScale;
						float z = 1.062f;
						Vector3 localScale2 = this.MaleAccessories[1].transform.localScale;
						float num2 = localScale2.z = z;
						Vector3 vector2 = this.MaleAccessories[1].transform.localScale = localScale2;
					}
				}
				if (PlayerPrefs.GetInt("CustomSuitorBlonde") > 0)
				{
					this.HairColor = "Yellow";
				}
				if (PlayerPrefs.GetInt("CustomSuitorJewelry") > 0)
				{
					for (int i = 0; i < Extensions.get_length(this.GaloAccessories); i++)
					{
						this.GaloAccessories[i].active = true;
					}
				}
			}
		}
		if (this.Club == 100)
		{
			this.MyRenderer.sharedMesh = this.TeacherMesh;
			this.Teacher = true;
		}
		else if (this.Club == 101)
		{
			if (PlayerPrefs.GetInt("Student_" + this.StudentID + "_Replaced") == 0)
			{
				this.Character.animation["f02_smile_00"].layer = 1;
				this.Character.animation.Play("f02_smile_00");
				this.Character.animation["f02_smile_00"].weight = (float)1;
				this.RightEyeRenderer.gameObject.active = false;
				this.LeftEyeRenderer.gameObject.active = false;
			}
			this.MyRenderer.sharedMesh = this.CoachMesh;
			this.Teacher = true;
		}
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.FemaleAccessories))
		{
			if (this.FemaleAccessories[this.ID] != null)
			{
				this.FemaleAccessories[this.ID].active = false;
			}
			this.ID++;
		}
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.MaleAccessories))
		{
			if (this.MaleAccessories[this.ID] != null)
			{
				this.MaleAccessories[this.ID].active = false;
			}
			this.ID++;
		}
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.ClubAccessories))
		{
			if (this.ClubAccessories[this.ID] != null)
			{
				this.ClubAccessories[this.ID].active = false;
			}
			this.ID++;
		}
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.TeacherAccessories))
		{
			if (this.TeacherAccessories[this.ID] != null)
			{
				this.TeacherAccessories[this.ID].active = false;
			}
			this.ID++;
		}
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.TeacherHair))
		{
			if (this.TeacherHair[this.ID] != null)
			{
				this.TeacherHair[this.ID].active = false;
			}
			this.ID++;
		}
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.FemaleHair))
		{
			if (this.FemaleHair[this.ID] != null)
			{
				this.FemaleHair[this.ID].active = false;
			}
			this.ID++;
		}
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.MaleHair))
		{
			if (this.MaleHair[this.ID] != null)
			{
				this.MaleHair[this.ID].active = false;
			}
			this.ID++;
		}
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.FacialHair))
		{
			if (this.FacialHair[this.ID] != null)
			{
				this.FacialHair[this.ID].active = false;
			}
			this.ID++;
		}
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.Eyewear))
		{
			if (this.Eyewear[this.ID] != null)
			{
				this.Eyewear[this.ID].active = false;
			}
			this.ID++;
		}
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.RightStockings))
		{
			if (this.RightStockings[this.ID] != null)
			{
				this.RightStockings[this.ID].active = false;
			}
			if (this.LeftStockings[this.ID] != null)
			{
				this.LeftStockings[this.ID].active = false;
			}
			this.ID++;
		}
		if (this.StudentID == 13 && PlayerPrefs.GetInt("CustomSuitor") == 1 && PlayerPrefs.GetInt("CustomSuitorEyewear") > 0)
		{
			this.Eyewear[PlayerPrefs.GetInt("CustomSuitorEyewear")].active = true;
		}
		if (this.StudentID == 1 && PlayerPrefs.GetInt("CustomSenpai") == 1)
		{
			if (PlayerPrefs.GetInt("SenpaiEyeWear") > 0)
			{
				this.Eyewear[PlayerPrefs.GetInt("SenpaiEyeWear")].active = true;
			}
			this.FacialHairstyle = PlayerPrefs.GetInt("SenpaiFacialHair");
			this.HairColor = PlayerPrefs.GetString("SenpaiHairColor");
			this.EyeColor = PlayerPrefs.GetString("SenpaiEyeColor");
			this.Hairstyle = PlayerPrefs.GetInt("SenpaiHairStyle");
		}
		if (!this.Male)
		{
			if (!this.Teacher)
			{
				this.FemaleHair[this.Hairstyle].active = true;
				this.HairRenderer = this.FemaleHairRenderers[this.Hairstyle];
				this.SetFemaleUniform();
			}
			else
			{
				this.TeacherHair[this.Hairstyle].active = true;
				this.HairRenderer = this.TeacherHairRenderers[this.Hairstyle];
				if (this.Club == 100)
				{
					this.MyRenderer.materials[0].mainTexture = this.TeacherBodyTexture;
					this.MyRenderer.materials[1].mainTexture = this.DefaultFaceTexture;
					this.MyRenderer.materials[2].mainTexture = this.TeacherBodyTexture;
				}
				else
				{
					this.MyRenderer.materials[0].mainTexture = this.CoachFaceTexture;
					this.MyRenderer.materials[1].mainTexture = this.CoachBodyTexture;
					this.MyRenderer.materials[2].mainTexture = this.CoachBodyTexture;
				}
			}
		}
		else
		{
			if (this.Hairstyle > 0)
			{
				this.MaleHair[this.Hairstyle].active = true;
				this.HairRenderer = this.MaleHairRenderers[this.Hairstyle];
			}
			if (this.FacialHairstyle > 0)
			{
				this.FacialHair[this.FacialHairstyle].active = true;
				this.FacialHairRenderer = this.FacialHairRenderers[this.FacialHairstyle];
			}
			this.SetMaleUniform();
		}
		if (!this.Male)
		{
			if (!this.Teacher)
			{
				if (this.FemaleAccessories[this.Accessory] != null)
				{
					this.FemaleAccessories[this.Accessory].active = true;
				}
			}
			else if (this.TeacherAccessories[this.Accessory] != null)
			{
				this.TeacherAccessories[this.Accessory].active = true;
			}
		}
		else if (this.MaleAccessories[this.Accessory] != null)
		{
			this.MaleAccessories[this.Accessory].active = true;
		}
		if (this.Club < 11 && this.ClubAccessories[this.Club] != null && PlayerPrefs.GetInt("Club_" + this.Club + "_Closed") == 0 && this.StudentID != 26)
		{
			this.ClubAccessories[this.Club].active = true;
		}
		if (!this.Male)
		{
			this.StartCoroutine_Auto(this.PutOnStockings());
		}
		if (!this.Randomize)
		{
			if (this.EyeColor != string.Empty)
			{
				if (this.EyeColor == "White")
				{
					this.CorrectColor = new Color((float)1, (float)1, (float)1);
				}
				else if (this.EyeColor == "Black")
				{
					this.CorrectColor = new Color(0.5f, 0.5f, 0.5f);
				}
				else if (this.EyeColor == "Red")
				{
					this.CorrectColor = new Color((float)1, (float)0, (float)0);
				}
				else if (this.EyeColor == "Yellow")
				{
					this.CorrectColor = new Color((float)1, (float)1, (float)0);
				}
				else if (this.EyeColor == "Green")
				{
					this.CorrectColor = new Color((float)0, (float)1, (float)0);
				}
				else if (this.EyeColor == "Cyan")
				{
					this.CorrectColor = new Color((float)0, (float)1, (float)1);
				}
				else if (this.EyeColor == "Blue")
				{
					this.CorrectColor = new Color((float)0, (float)0, (float)1);
				}
				else if (this.EyeColor == "Purple")
				{
					this.CorrectColor = new Color((float)1, (float)0, (float)1);
				}
				else if (this.EyeColor == "Orange")
				{
					this.CorrectColor = new Color((float)1, 0.5f, (float)0);
				}
				else if (this.EyeColor == "Brown")
				{
					this.CorrectColor = new Color(0.5f, 0.25f, (float)0);
				}
				else
				{
					this.CorrectColor = new Color((float)0, (float)0, (float)0);
				}
				if (this.CorrectColor != new Color((float)0, (float)0, (float)0))
				{
					this.RightEyeRenderer.material.color = this.CorrectColor;
					this.LeftEyeRenderer.material.color = this.CorrectColor;
				}
			}
		}
		else
		{
			float num3 = UnityEngine.Random.Range((float)0, 1f);
			float num4 = UnityEngine.Random.Range((float)0, 1f);
			float num5 = UnityEngine.Random.Range((float)0, 1f);
			float r = num3;
			Color color = this.RightEyeRenderer.material.color;
			float num6 = color.r = r;
			Color color2 = this.RightEyeRenderer.material.color = color;
			float g = num4;
			Color color3 = this.RightEyeRenderer.material.color;
			float num7 = color3.g = g;
			Color color4 = this.RightEyeRenderer.material.color = color3;
			float b = num5;
			Color color5 = this.RightEyeRenderer.material.color;
			float num8 = color5.b = b;
			Color color6 = this.RightEyeRenderer.material.color = color5;
			float r2 = num3;
			Color color7 = this.LeftEyeRenderer.material.color;
			float num9 = color7.r = r2;
			Color color8 = this.LeftEyeRenderer.material.color = color7;
			float g2 = num4;
			Color color9 = this.LeftEyeRenderer.material.color;
			float num10 = color9.g = g2;
			Color color10 = this.LeftEyeRenderer.material.color = color9;
			float b2 = num5;
			Color color11 = this.LeftEyeRenderer.material.color;
			float num11 = color11.b = b2;
			Color color12 = this.LeftEyeRenderer.material.color = color11;
		}
		if (!this.Randomize)
		{
			if (this.HairColor == "White")
			{
				this.ColorValue = new Color((float)1, (float)1, (float)1);
			}
			else if (this.HairColor == "Black")
			{
				this.ColorValue = new Color(0.5f, 0.5f, 0.5f);
			}
			else if (this.HairColor == "Red")
			{
				this.ColorValue = new Color((float)1, (float)0, (float)0);
			}
			else if (this.HairColor == "Yellow")
			{
				this.ColorValue = new Color((float)1, (float)1, (float)0);
			}
			else if (this.HairColor == "Green")
			{
				this.ColorValue = new Color((float)0, (float)1, (float)0);
			}
			else if (this.HairColor == "Cyan")
			{
				this.ColorValue = new Color((float)0, (float)1, (float)1);
			}
			else if (this.HairColor == "Blue")
			{
				this.ColorValue = new Color((float)0, (float)0, (float)1);
			}
			else if (this.HairColor == "Purple")
			{
				this.ColorValue = new Color((float)1, (float)0, (float)1);
			}
			else if (this.HairColor == "Orange")
			{
				this.ColorValue = new Color((float)1, 0.5f, (float)0);
			}
			else if (this.HairColor == "Brown")
			{
				this.ColorValue = new Color(0.5f, 0.25f, (float)0);
			}
			else
			{
				this.CorrectColor = new Color((float)0, (float)0, (float)0);
			}
			if (this.CorrectColor == new Color((float)0, (float)0, (float)0))
			{
				this.RightEyeRenderer.material.mainTexture = this.HairRenderer.material.mainTexture;
				this.LeftEyeRenderer.material.mainTexture = this.HairRenderer.material.mainTexture;
				this.FaceTexture = this.HairRenderer.material.mainTexture;
				this.CustomHair = true;
			}
			if (this.Hairstyle > 0)
			{
				this.HairRenderer.material.color = this.ColorValue;
			}
			if (!this.Male && this.Accessory == 6)
			{
				((Renderer)this.FemaleAccessories[6].GetComponent(typeof(Renderer))).material.color = this.ColorValue;
			}
		}
		else
		{
			float r3 = UnityEngine.Random.Range((float)0, 1f);
			Color color13 = this.HairRenderer.material.color;
			float num12 = color13.r = r3;
			Color color14 = this.HairRenderer.material.color = color13;
			float g3 = UnityEngine.Random.Range((float)0, 1f);
			Color color15 = this.HairRenderer.material.color;
			float num13 = color15.g = g3;
			Color color16 = this.HairRenderer.material.color = color15;
			float b3 = UnityEngine.Random.Range((float)0, 1f);
			Color color17 = this.HairRenderer.material.color;
			float num14 = color17.b = b3;
			Color color18 = this.HairRenderer.material.color = color17;
		}
		if (!this.Teacher)
		{
			if (this.CustomHair)
			{
				if (!this.Male)
				{
					this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
				}
				else if (PlayerPrefs.GetInt("MaleUniform") == 1)
				{
					this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
				}
				else if (PlayerPrefs.GetInt("MaleUniform") < 4)
				{
					this.MyRenderer.materials[1].mainTexture = this.FaceTexture;
				}
				else
				{
					this.MyRenderer.materials[0].mainTexture = this.FaceTexture;
				}
			}
			else
			{
				this.RightEyeRenderer.material.color = this.ColorValue;
				this.LeftEyeRenderer.material.color = this.ColorValue;
			}
		}
		else if (this.Teacher)
		{
			if (PlayerPrefs.GetInt("Student_" + this.StudentID + "_Replaced") == 1)
			{
				float @float = PlayerPrefs.GetFloat("Student_" + this.StudentID + "_ColorR");
				float float2 = PlayerPrefs.GetFloat("Student_" + this.StudentID + "_ColorG");
				float float3 = PlayerPrefs.GetFloat("Student_" + this.StudentID + "_ColorB");
				this.HairRenderer.material.color = new Color(@float, float2, float3);
			}
			this.RightEyeRenderer.material.color = this.HairRenderer.material.color;
			this.LeftEyeRenderer.material.color = this.HairRenderer.material.color;
		}
		if (this.Male)
		{
			if (this.Accessory == 2)
			{
				this.RightIrisLight.active = false;
				this.LeftIrisLight.active = false;
			}
			if (Application.loadedLevelName == "PortraitScene")
			{
				this.Character.transform.localScale = new Vector3(0.93f, 0.93f, 0.93f);
			}
			if (this.FacialHairRenderer != null)
			{
				this.FacialHairRenderer.material.color = this.ColorValue;
				if (Extensions.get_length(this.FacialHairRenderer.materials) > 1)
				{
					this.FacialHairRenderer.materials[1].color = this.ColorValue;
				}
			}
		}
		if (this.StudentID == 17)
		{
			if (PlayerPrefs.GetInt("Scheme_2_Stage") == 2)
			{
				this.FemaleAccessories[3].active = false;
			}
		}
		else if (this.StudentID == 20 && this.transform.position != new Vector3((float)0, (float)0, (float)0))
		{
			this.RightEyeRenderer.material.mainTexture = this.DefaultFaceTexture;
			this.LeftEyeRenderer.material.mainTexture = this.DefaultFaceTexture;
			((RainbowScript)this.RightEyeRenderer.gameObject.GetComponent(typeof(RainbowScript))).enabled = true;
			((RainbowScript)this.LeftEyeRenderer.gameObject.GetComponent(typeof(RainbowScript))).enabled = true;
		}
		if (this.Student != null && this.Student.AoT)
		{
			this.Student.AttackOnTitan();
		}
		this.TaskCheck();
		this.TurnOnCheck();
	}

	// Token: 0x060002AD RID: 685 RVA: 0x00033CBC File Offset: 0x00031EBC
	public virtual void SetMaleUniform()
	{
		if (this.StudentID == 1)
		{
			this.SkinColor = PlayerPrefs.GetInt("SenpaiSkinColor");
			this.FaceTexture = this.FaceTextures[this.SkinColor];
		}
		else
		{
			if (this.CustomHair)
			{
				this.FaceTexture = this.HairRenderer.material.mainTexture;
			}
			else
			{
				this.FaceTexture = this.FaceTextures[this.SkinColor];
			}
			if (this.StudentID == 13 && PlayerPrefs.GetInt("CustomSuitor") == 1 && PlayerPrefs.GetInt("CustomSuitorTan") == 1)
			{
				this.SkinColor = 6;
				this.FaceTexture = this.FaceTextures[6];
			}
		}
		this.MyRenderer.sharedMesh = this.MaleUniforms[PlayerPrefs.GetInt("MaleUniform")];
		this.SchoolUniform = this.MaleUniforms[PlayerPrefs.GetInt("MaleUniform")];
		this.UniformTexture = this.MaleUniformTextures[PlayerPrefs.GetInt("MaleUniform")];
		this.CasualTexture = this.MaleCasualTextures[PlayerPrefs.GetInt("MaleUniform")];
		this.SocksTexture = this.MaleSocksTextures[PlayerPrefs.GetInt("MaleUniform")];
		if (PlayerPrefs.GetInt("MaleUniform") == 1)
		{
			this.SkinID = 0;
			this.UniformID = 1;
			this.FaceID = 2;
		}
		else if (PlayerPrefs.GetInt("MaleUniform") == 2)
		{
			this.UniformID = 0;
			this.FaceID = 1;
			this.SkinID = 2;
		}
		else if (PlayerPrefs.GetInt("MaleUniform") == 3)
		{
			this.UniformID = 0;
			this.FaceID = 1;
			this.SkinID = 2;
		}
		else if (PlayerPrefs.GetInt("MaleUniform") == 4)
		{
			this.FaceID = 0;
			this.SkinID = 1;
			this.UniformID = 2;
		}
		else if (PlayerPrefs.GetInt("MaleUniform") == 5)
		{
			this.FaceID = 0;
			this.SkinID = 1;
			this.UniformID = 2;
		}
		else if (PlayerPrefs.GetInt("MaleUniform") == 6)
		{
			this.FaceID = 0;
			this.SkinID = 1;
			this.UniformID = 2;
		}
		if (!this.Student.Indoors)
		{
			this.MyRenderer.materials[this.FaceID].mainTexture = this.FaceTexture;
			this.MyRenderer.materials[this.SkinID].mainTexture = this.SkinTextures[this.SkinColor];
			this.MyRenderer.materials[this.UniformID].mainTexture = this.CasualTexture;
		}
		else
		{
			this.MyRenderer.materials[this.FaceID].mainTexture = this.FaceTexture;
			this.MyRenderer.materials[this.SkinID].mainTexture = this.SkinTextures[this.SkinColor];
			this.MyRenderer.materials[this.UniformID].mainTexture = this.UniformTexture;
		}
	}

	// Token: 0x060002AE RID: 686 RVA: 0x00033FBC File Offset: 0x000321BC
	public virtual void SetFemaleUniform()
	{
		this.MyRenderer.sharedMesh = this.FemaleUniforms[PlayerPrefs.GetInt("FemaleUniform")];
		this.SchoolUniform = this.FemaleUniforms[PlayerPrefs.GetInt("FemaleUniform")];
		if (this.StudentID == 26)
		{
			this.UniformTexture = this.OccultUniformTextures[PlayerPrefs.GetInt("FemaleUniform")];
			this.CasualTexture = this.OccultCasualTextures[PlayerPrefs.GetInt("FemaleUniform")];
			this.SocksTexture = this.OccultSocksTextures[PlayerPrefs.GetInt("FemaleUniform")];
		}
		else if (this.StudentID == 32)
		{
			this.UniformTexture = this.GanguroUniformTextures[PlayerPrefs.GetInt("FemaleUniform")];
			this.CasualTexture = this.GanguroCasualTextures[PlayerPrefs.GetInt("FemaleUniform")];
			this.SocksTexture = this.GanguroSocksTextures[PlayerPrefs.GetInt("FemaleUniform")];
		}
		else
		{
			this.UniformTexture = this.FemaleUniformTextures[PlayerPrefs.GetInt("FemaleUniform")];
			this.CasualTexture = this.FemaleCasualTextures[PlayerPrefs.GetInt("FemaleUniform")];
			this.SocksTexture = this.FemaleSocksTextures[PlayerPrefs.GetInt("FemaleUniform")];
		}
		if (!this.Cutscene)
		{
			if (!this.Kidnapped)
			{
				if (!this.Student.Indoors)
				{
					this.MyRenderer.materials[0].mainTexture = this.CasualTexture;
					this.MyRenderer.materials[1].mainTexture = this.CasualTexture;
				}
				else
				{
					this.MyRenderer.materials[0].mainTexture = this.UniformTexture;
					this.MyRenderer.materials[1].mainTexture = this.UniformTexture;
				}
			}
			else
			{
				this.MyRenderer.materials[0].mainTexture = this.UniformTexture;
				this.MyRenderer.materials[1].mainTexture = this.UniformTexture;
			}
		}
		else
		{
			this.MyRenderer.materials[0].mainTexture = this.UniformTexture;
			this.MyRenderer.materials[1].mainTexture = this.UniformTexture;
		}
		this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
		if (!this.TakingPortrait && this.Student != null && this.Student.StudentManager != null && this.Student.StudentManager.Censor)
		{
			this.CensorPanties();
		}
		if (this.MyStockings != null)
		{
			this.StartCoroutine_Auto(this.PutOnStockings());
		}
	}

	// Token: 0x060002AF RID: 687 RVA: 0x00034268 File Offset: 0x00032468
	public virtual void CensorPanties()
	{
		this.MyRenderer.materials[0].SetFloat("_BlendAmount1", (float)1);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount1", (float)1);
	}

	// Token: 0x060002B0 RID: 688 RVA: 0x000342A8 File Offset: 0x000324A8
	public virtual void RemoveCensor()
	{
		this.MyRenderer.materials[0].SetFloat("_BlendAmount1", (float)0);
		this.MyRenderer.materials[1].SetFloat("_BlendAmount1", (float)0);
	}

	// Token: 0x060002B1 RID: 689 RVA: 0x000342E8 File Offset: 0x000324E8
	public virtual void TaskCheck()
	{
		if (this.StudentID == 15)
		{
			if (PlayerPrefs.GetInt("Task_15_Status") < 3)
			{
				this.MaleAccessories[1].active = false;
			}
		}
		else if (this.StudentID == 33 && PlayerPrefs.GetInt("Task_33_Status") < 3)
		{
			this.Charm.active = true;
		}
	}

	// Token: 0x060002B2 RID: 690 RVA: 0x00034350 File Offset: 0x00032550
	public virtual void TurnOnCheck()
	{
		if (!this.TakingPortrait && this.Male)
		{
			if (this.HairColor == "Purple")
			{
				this.LoveManager.Targets[this.LoveManager.TotalTargets] = this.Student.Head;
				this.LoveManager.TotalTargets = this.LoveManager.TotalTargets + 1;
			}
			if (this.MaleAccessories[2].active)
			{
				this.LoveManager.Targets[this.LoveManager.TotalTargets] = this.Student.Head;
				this.LoveManager.TotalTargets = this.LoveManager.TotalTargets + 1;
			}
			if (this.MaleAccessories[3].active)
			{
				this.LoveManager.Targets[this.LoveManager.TotalTargets] = this.Student.Head;
				this.LoveManager.TotalTargets = this.LoveManager.TotalTargets + 1;
			}
		}
	}

	// Token: 0x060002B3 RID: 691 RVA: 0x00034460 File Offset: 0x00032660
	public virtual void DestroyUnneccessaryObjects()
	{
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.FemaleAccessories))
		{
			if (this.FemaleAccessories[this.ID] != null && !this.FemaleAccessories[this.ID].active)
			{
				UnityEngine.Object.Destroy(this.FemaleAccessories[this.ID]);
			}
			this.ID++;
		}
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.MaleAccessories))
		{
			if (this.MaleAccessories[this.ID] != null && !this.MaleAccessories[this.ID].active)
			{
				UnityEngine.Object.Destroy(this.MaleAccessories[this.ID]);
			}
			this.ID++;
		}
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.ClubAccessories))
		{
			if (this.ClubAccessories[this.ID] != null && !this.ClubAccessories[this.ID].active)
			{
				UnityEngine.Object.Destroy(this.ClubAccessories[this.ID]);
			}
			this.ID++;
		}
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.TeacherAccessories))
		{
			if (this.TeacherAccessories[this.ID] != null && !this.TeacherAccessories[this.ID].active)
			{
				UnityEngine.Object.Destroy(this.TeacherAccessories[this.ID]);
			}
			this.ID++;
		}
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.TeacherHair))
		{
			if (this.TeacherHair[this.ID] != null && !this.TeacherHair[this.ID].active)
			{
				UnityEngine.Object.Destroy(this.TeacherHair[this.ID]);
			}
			this.ID++;
		}
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.FemaleHair))
		{
			if (this.FemaleHair[this.ID] != null && !this.FemaleHair[this.ID].active)
			{
				UnityEngine.Object.Destroy(this.FemaleHair[this.ID]);
			}
			this.ID++;
		}
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.MaleHair))
		{
			if (this.MaleHair[this.ID] != null && !this.MaleHair[this.ID].active)
			{
				UnityEngine.Object.Destroy(this.MaleHair[this.ID]);
			}
			this.ID++;
		}
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.FacialHair))
		{
			if (this.FacialHair[this.ID] != null && !this.FacialHair[this.ID].active)
			{
				UnityEngine.Object.Destroy(this.FacialHair[this.ID]);
			}
			this.ID++;
		}
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.Eyewear))
		{
			if (this.Eyewear[this.ID] != null && !this.Eyewear[this.ID].active)
			{
				UnityEngine.Object.Destroy(this.Eyewear[this.ID]);
			}
			this.ID++;
		}
		this.ID = 0;
		while (this.ID < Extensions.get_length(this.RightStockings))
		{
			if (this.RightStockings[this.ID] != null && !this.RightStockings[this.ID].active)
			{
				UnityEngine.Object.Destroy(this.RightStockings[this.ID]);
			}
			if (this.LeftStockings[this.ID] != null && !this.LeftStockings[this.ID].active)
			{
				UnityEngine.Object.Destroy(this.LeftStockings[this.ID]);
			}
			this.ID++;
		}
	}

	// Token: 0x060002B4 RID: 692 RVA: 0x00034918 File Offset: 0x00032B18
	public virtual IEnumerator PutOnStockings()
	{
		return new CosmeticScript.$PutOnStockings$3094(this).GetEnumerator();
	}

	// Token: 0x060002B5 RID: 693 RVA: 0x00034928 File Offset: 0x00032B28
	public virtual void Main()
	{
	}

	// Token: 0x04000603 RID: 1539
	public StudentManagerScript StudentManager;

	// Token: 0x04000604 RID: 1540
	public TextureManagerScript TextureManager;

	// Token: 0x04000605 RID: 1541
	public SkinnedMeshUpdater SkinUpdater;

	// Token: 0x04000606 RID: 1542
	public LoveManagerScript LoveManager;

	// Token: 0x04000607 RID: 1543
	public StudentScript Student;

	// Token: 0x04000608 RID: 1544
	public JsonScript JSON;

	// Token: 0x04000609 RID: 1545
	public GameObject[] TeacherAccessories;

	// Token: 0x0400060A RID: 1546
	public GameObject[] FemaleAccessories;

	// Token: 0x0400060B RID: 1547
	public GameObject[] MaleAccessories;

	// Token: 0x0400060C RID: 1548
	public GameObject[] ClubAccessories;

	// Token: 0x0400060D RID: 1549
	public GameObject[] RightStockings;

	// Token: 0x0400060E RID: 1550
	public GameObject[] LeftStockings;

	// Token: 0x0400060F RID: 1551
	public GameObject[] TeacherHair;

	// Token: 0x04000610 RID: 1552
	public GameObject[] FacialHair;

	// Token: 0x04000611 RID: 1553
	public GameObject[] FemaleHair;

	// Token: 0x04000612 RID: 1554
	public GameObject[] MaleHair;

	// Token: 0x04000613 RID: 1555
	public GameObject[] Eyewear;

	// Token: 0x04000614 RID: 1556
	public Renderer[] TeacherHairRenderers;

	// Token: 0x04000615 RID: 1557
	public Renderer[] FacialHairRenderers;

	// Token: 0x04000616 RID: 1558
	public Renderer[] FemaleHairRenderers;

	// Token: 0x04000617 RID: 1559
	public Renderer[] MaleHairRenderers;

	// Token: 0x04000618 RID: 1560
	public Texture[] GanguroUniformTextures;

	// Token: 0x04000619 RID: 1561
	public Texture[] GanguroCasualTextures;

	// Token: 0x0400061A RID: 1562
	public Texture[] GanguroSocksTextures;

	// Token: 0x0400061B RID: 1563
	public Texture[] OccultUniformTextures;

	// Token: 0x0400061C RID: 1564
	public Texture[] OccultCasualTextures;

	// Token: 0x0400061D RID: 1565
	public Texture[] OccultSocksTextures;

	// Token: 0x0400061E RID: 1566
	public Texture[] FemaleUniformTextures;

	// Token: 0x0400061F RID: 1567
	public Texture[] FemaleCasualTextures;

	// Token: 0x04000620 RID: 1568
	public Texture[] FemaleSocksTextures;

	// Token: 0x04000621 RID: 1569
	public Texture[] MaleUniformTextures;

	// Token: 0x04000622 RID: 1570
	public Texture[] MaleCasualTextures;

	// Token: 0x04000623 RID: 1571
	public Texture[] MaleSocksTextures;

	// Token: 0x04000624 RID: 1572
	public Texture[] FaceTextures;

	// Token: 0x04000625 RID: 1573
	public Texture[] SkinTextures;

	// Token: 0x04000626 RID: 1574
	public Mesh[] FemaleUniforms;

	// Token: 0x04000627 RID: 1575
	public Mesh[] MaleUniforms;

	// Token: 0x04000628 RID: 1576
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x04000629 RID: 1577
	public Renderer FacialHairRenderer;

	// Token: 0x0400062A RID: 1578
	public Renderer RightEyeRenderer;

	// Token: 0x0400062B RID: 1579
	public Renderer LeftEyeRenderer;

	// Token: 0x0400062C RID: 1580
	public Renderer HairRenderer;

	// Token: 0x0400062D RID: 1581
	public Mesh SchoolUniform;

	// Token: 0x0400062E RID: 1582
	public Texture DefaultFaceTexture;

	// Token: 0x0400062F RID: 1583
	public Texture TeacherBodyTexture;

	// Token: 0x04000630 RID: 1584
	public Texture CoachBodyTexture;

	// Token: 0x04000631 RID: 1585
	public Texture CoachFaceTexture;

	// Token: 0x04000632 RID: 1586
	public Texture UniformTexture;

	// Token: 0x04000633 RID: 1587
	public Texture CasualTexture;

	// Token: 0x04000634 RID: 1588
	public Texture SocksTexture;

	// Token: 0x04000635 RID: 1589
	public Texture FaceTexture;

	// Token: 0x04000636 RID: 1590
	public Texture PurpleStockings;

	// Token: 0x04000637 RID: 1591
	public Texture YellowStockings;

	// Token: 0x04000638 RID: 1592
	public Texture GreenStockings;

	// Token: 0x04000639 RID: 1593
	public Texture OsanaStockings;

	// Token: 0x0400063A RID: 1594
	public Texture BlueStockings;

	// Token: 0x0400063B RID: 1595
	public Texture CyanStockings;

	// Token: 0x0400063C RID: 1596
	public Texture RedStockings;

	// Token: 0x0400063D RID: 1597
	public Texture CustomStockings;

	// Token: 0x0400063E RID: 1598
	public Texture MyStockings;

	// Token: 0x0400063F RID: 1599
	public GameObject RightIrisLight;

	// Token: 0x04000640 RID: 1600
	public GameObject LeftIrisLight;

	// Token: 0x04000641 RID: 1601
	public GameObject Character;

	// Token: 0x04000642 RID: 1602
	public GameObject RightShoe;

	// Token: 0x04000643 RID: 1603
	public GameObject LeftShoe;

	// Token: 0x04000644 RID: 1604
	public GameObject Charm;

	// Token: 0x04000645 RID: 1605
	public Transform RightBreast;

	// Token: 0x04000646 RID: 1606
	public Transform LeftBreast;

	// Token: 0x04000647 RID: 1607
	public Color CorrectColor;

	// Token: 0x04000648 RID: 1608
	public Color ColorValue;

	// Token: 0x04000649 RID: 1609
	public Mesh TeacherMesh;

	// Token: 0x0400064A RID: 1610
	public Mesh CoachMesh;

	// Token: 0x0400064B RID: 1611
	public bool TakingPortrait;

	// Token: 0x0400064C RID: 1612
	public bool Initialized;

	// Token: 0x0400064D RID: 1613
	public bool CustomHair;

	// Token: 0x0400064E RID: 1614
	public bool Kidnapped;

	// Token: 0x0400064F RID: 1615
	public bool Randomize;

	// Token: 0x04000650 RID: 1616
	public bool Cutscene;

	// Token: 0x04000651 RID: 1617
	public bool Teacher;

	// Token: 0x04000652 RID: 1618
	public bool Male;

	// Token: 0x04000653 RID: 1619
	public float BreastSize;

	// Token: 0x04000654 RID: 1620
	public string HairColor;

	// Token: 0x04000655 RID: 1621
	public string Stockings;

	// Token: 0x04000656 RID: 1622
	public string EyeColor;

	// Token: 0x04000657 RID: 1623
	public int FacialHairstyle;

	// Token: 0x04000658 RID: 1624
	public int Accessory;

	// Token: 0x04000659 RID: 1625
	public int Hairstyle;

	// Token: 0x0400065A RID: 1626
	public int SkinColor;

	// Token: 0x0400065B RID: 1627
	public int StudentID;

	// Token: 0x0400065C RID: 1628
	public int Club;

	// Token: 0x0400065D RID: 1629
	public int ID;

	// Token: 0x0400065E RID: 1630
	public GameObject[] GaloAccessories;

	// Token: 0x0400065F RID: 1631
	public int FaceID;

	// Token: 0x04000660 RID: 1632
	public int SkinID;

	// Token: 0x04000661 RID: 1633
	public int UniformID;

	// Token: 0x0200006E RID: 110
	[CompilerGenerated]
	[Serializable]
	internal sealed class $PutOnStockings$3094 : GenericGenerator<WWW>
	{
		// Token: 0x060002B6 RID: 694 RVA: 0x0003492C File Offset: 0x00032B2C
		public $PutOnStockings$3094(CosmeticScript self_)
		{
			this.$self_$3097 = self_;
		}

		// Token: 0x060002B7 RID: 695 RVA: 0x0003493C File Offset: 0x00032B3C
		public override IEnumerator<WWW> GetEnumerator()
		{
			return new CosmeticScript.$PutOnStockings$3094.$(this.$self_$3097);
		}

		// Token: 0x04000662 RID: 1634
		internal CosmeticScript $self_$3097;
	}
}
