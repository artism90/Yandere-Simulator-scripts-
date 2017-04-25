using System;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

// Token: 0x02000084 RID: 132
[Serializable]
public class DoorScript : MonoBehaviour
{
	// Token: 0x06000320 RID: 800 RVA: 0x000413F8 File Offset: 0x0003F5F8
	public DoorScript()
	{
		this.ShiftNorth = -0.1f;
		this.ShiftSouth = 0.1f;
		this.Swing = 150f;
		this.RoomName = string.Empty;
		this.Facing = string.Empty;
	}

	// Token: 0x06000321 RID: 801 RVA: 0x00041438 File Offset: 0x0003F638
	public virtual void Start()
	{
		this.Yandere = (YandereScript)GameObject.Find("YandereChan").GetComponent(typeof(YandereScript));
		if (this.Swinging)
		{
			this.OriginX[0] = this.Doors[0].transform.localPosition.z;
			if (Extensions.get_length(this.OriginX) > 1)
			{
				this.OriginX[1] = this.Doors[1].transform.localPosition.z;
			}
		}
		if (Extensions.get_length(this.Labels) > 0)
		{
			this.Labels[0].text = this.RoomName;
			this.Labels[1].text = this.RoomName;
			this.UpdatePlate();
		}
		if (this.Club != 0 && PlayerPrefs.GetInt("Club_" + this.Club + "_Closed") == 1)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			this.enabled = false;
		}
	}

	// Token: 0x06000322 RID: 802 RVA: 0x0004155C File Offset: 0x0003F75C
	public virtual void Update()
	{
		if (Vector3.Distance(this.Yandere.transform.position, this.transform.position) < (float)1)
		{
			if (!this.Near)
			{
				this.TopicCheck();
				this.Yandere.Location.Label.text = this.RoomName;
				this.Yandere.Location.Show = true;
				this.Near = true;
			}
		}
		else if (this.Near)
		{
			this.Yandere.Location.Show = false;
			this.Near = false;
		}
		if (this.Prompt.Circle[0].fillAmount == (float)0)
		{
			this.Prompt.Circle[0].fillAmount = (float)1;
			if (!this.Open)
			{
				this.OpenDoor();
			}
			else
			{
				this.CloseDoor();
			}
		}
		if (this.Timer < (float)2)
		{
			this.Timer += Time.deltaTime;
			if (!this.Open)
			{
				for (int i = 0; i < Extensions.get_length(this.Doors); i++)
				{
					if (!this.Swinging)
					{
						float x = Mathf.Lerp(this.Doors[i].localPosition.x, this.ClosedPositions[i], Time.deltaTime * 3.6f);
						Vector3 localPosition = this.Doors[i].localPosition;
						float num = localPosition.x = x;
						Vector3 vector = this.Doors[i].localPosition = localPosition;
					}
					else
					{
						this.Rotation = Mathf.Lerp(this.Rotation, (float)0, Time.deltaTime * 3.6f);
						float z = Mathf.Lerp(this.Doors[i].localPosition.z, this.OriginX[i], Time.deltaTime * 3.6f);
						Vector3 localPosition2 = this.Doors[i].localPosition;
						float num2 = localPosition2.z = z;
						Vector3 vector2 = this.Doors[i].localPosition = localPosition2;
						if (i == 0)
						{
							float rotation = this.Rotation;
							Vector3 localEulerAngles = this.Doors[i].localEulerAngles;
							float num3 = localEulerAngles.y = rotation;
							Vector3 vector3 = this.Doors[i].localEulerAngles = localEulerAngles;
						}
						else
						{
							float y = this.Rotation * (float)-1;
							Vector3 localEulerAngles2 = this.Doors[i].localEulerAngles;
							float num4 = localEulerAngles2.y = y;
							Vector3 vector4 = this.Doors[i].localEulerAngles = localEulerAngles2;
						}
					}
				}
			}
			else
			{
				for (int i = 0; i < Extensions.get_length(this.Doors); i++)
				{
					if (!this.Swinging)
					{
						float x2 = Mathf.Lerp(this.Doors[i].localPosition.x, this.OpenPositions[i], Time.deltaTime * 3.6f);
						Vector3 localPosition3 = this.Doors[i].localPosition;
						float num5 = localPosition3.x = x2;
						Vector3 vector5 = this.Doors[i].localPosition = localPosition3;
					}
					else
					{
						if (this.North)
						{
							float z2 = Mathf.Lerp(this.Doors[i].localPosition.z, this.OriginX[i] + this.ShiftNorth, Time.deltaTime * 3.6f);
							Vector3 localPosition4 = this.Doors[i].localPosition;
							float num6 = localPosition4.z = z2;
							Vector3 vector6 = this.Doors[i].localPosition = localPosition4;
						}
						else
						{
							float z3 = Mathf.Lerp(this.Doors[i].localPosition.z, this.OriginX[i] + this.ShiftSouth, Time.deltaTime * 3.6f);
							Vector3 localPosition5 = this.Doors[i].localPosition;
							float num7 = localPosition5.z = z3;
							Vector3 vector7 = this.Doors[i].localPosition = localPosition5;
						}
						if (this.North)
						{
							this.Rotation = Mathf.Lerp(this.Rotation, this.Swing, Time.deltaTime * 3.6f);
						}
						else
						{
							this.Rotation = Mathf.Lerp(this.Rotation, this.Swing * (float)-1, Time.deltaTime * 3.6f);
						}
						if (i == 0)
						{
							float rotation2 = this.Rotation;
							Vector3 localEulerAngles3 = this.Doors[i].localEulerAngles;
							float num8 = localEulerAngles3.y = rotation2;
							Vector3 vector8 = this.Doors[i].localEulerAngles = localEulerAngles3;
						}
						else
						{
							float y2 = this.Rotation * (float)-1;
							Vector3 localEulerAngles4 = this.Doors[i].localEulerAngles;
							float num9 = localEulerAngles4.y = y2;
							Vector3 vector9 = this.Doors[i].localEulerAngles = localEulerAngles4;
						}
					}
				}
			}
		}
		else if (this.Locked && this.Prompt.Circle[0].fillAmount < (float)1)
		{
			this.Prompt.Label[0].text = "     " + "Locked";
			this.Prompt.Circle[0].fillAmount = (float)1;
		}
		if (Input.GetKeyDown("space"))
		{
			this.UpdatePlate();
		}
	}

	// Token: 0x06000323 RID: 803 RVA: 0x00041AEC File Offset: 0x0003FCEC
	public virtual void OpenDoor()
	{
		this.Prompt.Label[0].text = "     " + "Close";
		this.Open = true;
		this.Timer = (float)0;
		if (this.HidingSpot)
		{
			UnityEngine.Object.Destroy(this.HideCollider.GetComponent("BoxCollider"));
		}
		this.CheckDirection();
	}

	// Token: 0x06000324 RID: 804 RVA: 0x00041B50 File Offset: 0x0003FD50
	public virtual void LockDoor()
	{
		this.Open = false;
		this.Prompt.Hide();
		this.Prompt.enabled = false;
	}

	// Token: 0x06000325 RID: 805 RVA: 0x00041B70 File Offset: 0x0003FD70
	public virtual void CheckDirection()
	{
		this.North = false;
		if (this.Student != null)
		{
			this.RelativeCharacter = this.Student.transform;
		}
		else
		{
			this.RelativeCharacter = this.Yandere.transform;
		}
		if (this.Facing == "North")
		{
			if (this.RelativeCharacter.position.z < this.transform.position.z)
			{
				this.North = true;
			}
		}
		else if (this.Facing == "South")
		{
			if (this.RelativeCharacter.position.z > this.transform.position.z)
			{
				this.North = true;
			}
		}
		else if (this.Facing == "East")
		{
			if (this.RelativeCharacter.position.x < this.transform.position.x)
			{
				this.North = true;
			}
		}
		else if (this.Facing == "West" && this.RelativeCharacter.position.x > this.transform.position.x)
		{
			this.North = true;
		}
		this.Student = null;
	}

	// Token: 0x06000326 RID: 806 RVA: 0x00041CF4 File Offset: 0x0003FEF4
	public virtual void CloseDoor()
	{
		this.Prompt.Label[0].text = "     " + "Open";
		this.Open = false;
		this.Timer = (float)0;
		if (this.HidingSpot)
		{
			this.HideCollider.gameObject.AddComponent("BoxCollider");
			int num = 2;
			Component component = this.HideCollider.GetComponent("BoxCollider");
			object property = UnityRuntimeServices.GetProperty(component, "size");
			RuntimeServices.SetProperty(property, "z", num);
			UnityRuntimeServices.PropagateValueTypeChanges(new UnityRuntimeServices.ValueTypeChange[]
			{
				new UnityRuntimeServices.MemberValueTypeChange(component, "size", property)
			});
			RuntimeServices.SetProperty(this.HideCollider.GetComponent("BoxCollider"), "isTrigger", true);
			this.HideCollider.MyCollider = (Collider)this.HideCollider.GetComponent("BoxCollider");
		}
	}

	// Token: 0x06000327 RID: 807 RVA: 0x00041DE8 File Offset: 0x0003FFE8
	public virtual void UpdatePlate()
	{
		int roomID = this.RoomID;
		if (roomID == 1)
		{
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2((float)0, 0.75f);
		}
		else if (roomID == 2)
		{
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2((float)0, 0.5f);
		}
		else if (roomID == 3)
		{
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2((float)0, 0.25f);
		}
		else if (roomID == 4)
		{
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2((float)0, (float)0);
		}
		else if (roomID == 5)
		{
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2(0.25f, 0.75f);
		}
		else if (roomID == 6)
		{
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2(0.25f, 0.5f);
		}
		else if (roomID == 7)
		{
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2(0.25f, 0.25f);
		}
		else if (roomID == 8)
		{
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2(0.25f, (float)0);
		}
		else if (roomID == 9)
		{
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2(0.5f, 0.75f);
		}
		else if (roomID == 10)
		{
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2(0.5f, 0.5f);
		}
		else if (roomID == 11)
		{
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2(0.5f, 0.25f);
		}
		else if (roomID == 12)
		{
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2(0.5f, (float)0);
		}
		else if (roomID == 13)
		{
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2(0.75f, 0.75f);
		}
		else if (roomID == 14)
		{
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2(0.75f, 0.5f);
		}
		else if (roomID == 15)
		{
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2(0.75f, 0.25f);
		}
		else if (roomID == 16)
		{
			this.Sign.material.mainTexture = this.Plates[1];
			this.Sign.material.mainTextureOffset = new Vector2(0.75f, (float)0);
		}
		else if (roomID == 17)
		{
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2((float)0, 0.75f);
		}
		else if (roomID == 18)
		{
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2((float)0, 0.5f);
		}
		else if (roomID == 19)
		{
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2((float)0, 0.25f);
		}
		else if (roomID == 20)
		{
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2((float)0, (float)0);
		}
		else if (roomID == 21)
		{
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2(0.25f, 0.75f);
		}
		else if (roomID == 22)
		{
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2(0.25f, 0.5f);
		}
		else if (roomID == 23)
		{
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2(0.25f, 0.25f);
		}
		else if (roomID == 24)
		{
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2(0.25f, (float)0);
		}
		else if (roomID == 25)
		{
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2(0.5f, 0.75f);
		}
		else if (roomID == 26)
		{
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2(0.5f, 0.5f);
		}
		else if (roomID == 27)
		{
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2(0.5f, 0.25f);
		}
		else if (roomID == 28)
		{
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2(0.5f, (float)0);
		}
		else if (roomID == 29)
		{
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2(0.75f, 0.75f);
		}
		else if (roomID == 30)
		{
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2(0.75f, 0.5f);
		}
		else if (roomID == 31)
		{
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2(0.75f, 0.25f);
		}
		else if (roomID == 32)
		{
			this.Sign.material.mainTexture = this.Plates[2];
			this.Sign.material.mainTextureOffset = new Vector2(0.75f, (float)0);
		}
		else if (roomID == 33)
		{
			this.Sign.material.mainTexture = this.Plates[3];
			this.Sign.material.mainTextureOffset = new Vector2((float)0, 0.75f);
		}
		else if (roomID == 34)
		{
			this.Sign.material.mainTexture = this.Plates[3];
			this.Sign.material.mainTextureOffset = new Vector2((float)0, 0.5f);
		}
	}

	// Token: 0x06000328 RID: 808 RVA: 0x000426CC File Offset: 0x000408CC
	public virtual void TopicCheck()
	{
		int roomID = this.RoomID;
		if (roomID != 1)
		{
			if (roomID != 2)
			{
				if (roomID == 3)
				{
					if (PlayerPrefs.GetInt("Topic_12_Discovered") == 0)
					{
						PlayerPrefs.SetInt("Topic_12_Discovered", 1);
						this.Yandere.NotificationManager.DisplayNotification("Topic");
					}
				}
				else if (roomID != 4)
				{
					if (roomID != 5)
					{
						if (roomID != 6)
						{
							if (roomID != 7)
							{
								if (roomID != 8)
								{
									if (roomID != 9)
									{
										if (roomID != 10)
										{
											if (roomID != 11)
											{
												if (roomID != 12)
												{
													if (roomID == 13)
													{
														if (PlayerPrefs.GetInt("Topic_21_Discovered") == 0)
														{
															PlayerPrefs.SetInt("Topic_21_Discovered", 1);
															this.Yandere.NotificationManager.DisplayNotification("Topic");
														}
													}
													else if (roomID != 14)
													{
														if (roomID == 15)
														{
															if (PlayerPrefs.GetInt("Topic_16_Discovered") == 0)
															{
																PlayerPrefs.SetInt("Topic_16_Discovered", 1);
																PlayerPrefs.SetInt("Topic_17_Discovered", 1);
																PlayerPrefs.SetInt("Topic_18_Discovered", 1);
																PlayerPrefs.SetInt("Topic_19_Discovered", 1);
																this.Yandere.NotificationManager.DisplayNotification("Topic");
																this.Yandere.NotificationManager.DisplayNotification("Topic");
																this.Yandere.NotificationManager.DisplayNotification("Topic");
																this.Yandere.NotificationManager.DisplayNotification("Topic");
															}
														}
														else if (roomID != 16)
														{
															if (roomID != 17)
															{
																if (roomID != 18)
																{
																	if (roomID != 19)
																	{
																		if (roomID != 20)
																		{
																			if (roomID != 21)
																			{
																				if (roomID != 22)
																				{
																					if (roomID != 23)
																					{
																						if (roomID != 24)
																						{
																							if (roomID != 25)
																							{
																								if (roomID == 26)
																								{
																									if (PlayerPrefs.GetInt("Topic_1_Discovered") == 0)
																									{
																										PlayerPrefs.SetInt("Topic_1_Discovered", 1);
																										this.Yandere.NotificationManager.DisplayNotification("Topic");
																									}
																								}
																								else if (roomID == 27)
																								{
																									if (PlayerPrefs.GetInt("Topic_2_Discovered") == 0)
																									{
																										PlayerPrefs.SetInt("Topic_2_Discovered", 1);
																										this.Yandere.NotificationManager.DisplayNotification("Topic");
																									}
																								}
																								else if (roomID == 28)
																								{
																									if (PlayerPrefs.GetInt("Topic_3_Discovered") == 0)
																									{
																										PlayerPrefs.SetInt("Topic_3_Discovered", 1);
																										this.Yandere.NotificationManager.DisplayNotification("Topic");
																									}
																								}
																								else if (roomID == 29)
																								{
																									if (PlayerPrefs.GetInt("Topic_4_Discovered") == 0)
																									{
																										PlayerPrefs.SetInt("Topic_4_Discovered", 1);
																										this.Yandere.NotificationManager.DisplayNotification("Topic");
																									}
																								}
																								else if (roomID == 30)
																								{
																									if (PlayerPrefs.GetInt("Topic_5_Discovered") == 0)
																									{
																										PlayerPrefs.SetInt("Topic_5_Discovered", 1);
																										this.Yandere.NotificationManager.DisplayNotification("Topic");
																									}
																								}
																								else if (roomID == 31)
																								{
																									if (PlayerPrefs.GetInt("Topic_6_Discovered") == 0)
																									{
																										PlayerPrefs.SetInt("Topic_6_Discovered", 1);
																										this.Yandere.NotificationManager.DisplayNotification("Topic");
																									}
																								}
																								else if (roomID == 32)
																								{
																									if (PlayerPrefs.GetInt("Topic_7_Discovered") == 0)
																									{
																										PlayerPrefs.SetInt("Topic_7_Discovered", 1);
																										this.Yandere.NotificationManager.DisplayNotification("Topic");
																									}
																								}
																								else if (roomID != 33)
																								{
																									if (roomID == 34)
																									{
																										if (PlayerPrefs.GetInt("Topic_8_Discovered") == 0)
																										{
																											PlayerPrefs.SetInt("Topic_8_Discovered", 1);
																											this.Yandere.NotificationManager.DisplayNotification("Topic");
																										}
																									}
																								}
																							}
																						}
																					}
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x06000329 RID: 809 RVA: 0x00042AFC File Offset: 0x00040CFC
	public virtual void Main()
	{
	}

	// Token: 0x040007E0 RID: 2016
	public Transform RelativeCharacter;

	// Token: 0x040007E1 RID: 2017
	public HideColliderScript HideCollider;

	// Token: 0x040007E2 RID: 2018
	public StudentScript Student;

	// Token: 0x040007E3 RID: 2019
	public YandereScript Yandere;

	// Token: 0x040007E4 RID: 2020
	public PromptScript Prompt;

	// Token: 0x040007E5 RID: 2021
	public float[] ClosedPositions;

	// Token: 0x040007E6 RID: 2022
	public float[] OpenPositions;

	// Token: 0x040007E7 RID: 2023
	public Transform[] Doors;

	// Token: 0x040007E8 RID: 2024
	public Texture[] Plates;

	// Token: 0x040007E9 RID: 2025
	public UILabel[] Labels;

	// Token: 0x040007EA RID: 2026
	public float[] OriginX;

	// Token: 0x040007EB RID: 2027
	public bool HidingSpot;

	// Token: 0x040007EC RID: 2028
	public bool Swinging;

	// Token: 0x040007ED RID: 2029
	public bool Locked;

	// Token: 0x040007EE RID: 2030
	public bool North;

	// Token: 0x040007EF RID: 2031
	public bool Open;

	// Token: 0x040007F0 RID: 2032
	public bool Near;

	// Token: 0x040007F1 RID: 2033
	public float ShiftNorth;

	// Token: 0x040007F2 RID: 2034
	public float ShiftSouth;

	// Token: 0x040007F3 RID: 2035
	public float Rotation;

	// Token: 0x040007F4 RID: 2036
	public float Swing;

	// Token: 0x040007F5 RID: 2037
	public float Timer;

	// Token: 0x040007F6 RID: 2038
	public Renderer Sign;

	// Token: 0x040007F7 RID: 2039
	public string RoomName;

	// Token: 0x040007F8 RID: 2040
	public string Facing;

	// Token: 0x040007F9 RID: 2041
	public int RoomID;

	// Token: 0x040007FA RID: 2042
	public int Club;
}
