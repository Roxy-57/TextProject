using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testProject2
{
    public partial class Form1 : Form
    {
        private string playerName;
        private int storyIndex;
        private List<string> story;
        private List<string> choices;
        private Random diceRoll;
        private Random storyRandomizer;
        private Monster currentMonster;
        private int monstersDefeated;
        private List<Monster> monsterTypes;

        private int health;
        private int stamina;
        private int diceResult;
        public Form1()
        {
            InitializeComponent();
            diceRoll = new Random();
            storyRandomizer = new Random();

            // 몬스터 타입 리스트 초기화
            monsterTypes = new List<Monster>
        {
            new Monster("슬라임", 50, 5),
            new Monster("스켈레톤", 30, 10),
            new Monster("고블린", 50, 15),
            new Monster("오크", 100, 20)
        };
            //보스
            currentMonster = null;
            monstersDefeated = 0;

            story = new List<string>
        {
            "당신은 길을 걸어가며 선택을 해야 합니다.",
            "위험한 상황에 직면했습니다. 어떻게 할까요?",
            "주위에 적들이 나타났습니다! 싸울 것인가, 도망칠 것인가?",
            "어두운 숲 속에 발을 들여놓았습니다. 그곳에는 무엇이 있을까요?"
        };
            choices = new List<string> { "싸운다.", "도망간다." };
            storyIndex = 0;
            lblResult.Width = 300;
            // 초기 체력과 행동력 
            health = 100;
            stamina = 60;

        }

        private void SummonMonster()
        {
            if (monstersDefeated >= 3)
            {
                // 보스를 소환
                currentMonster = new Monster("마왕", 200, 25);
                lblStory.Text = "마왕이 나타났다!";
            }
            else
            {
                // 일반 몬스터 소환
                int monsterIndex = storyRandomizer.Next(monsterTypes.Count);
                currentMonster = new Monster(monsterTypes[monsterIndex].Name, monsterTypes[monsterIndex].HP, monsterTypes[monsterIndex].Attack);
                lblStory.Text = $"{currentMonster.Name}가 나타났다!"; // 등장한 몬스터 이름을 표시
            }

            btnChoice1.Text = "싸운다";
            btnChoice2.Text = "도망간다";

            // 몬스터 상태 업데이트
            UpdateMonsterStatus(); // 여기에서 lblMonsterStatus에 상태를 표시

            // 몬스터 이미지 업데이트
            UpdateMonsterImage();
        }


        private void UpdateStatusDisplay()
        {
            lblStory.Text = $"{playerName}님, 체력: {health} / 행동력: {stamina}";

            if (currentMonster != null)
            {
                lblMonsterStatus.Text = currentMonster.Encountered
                    ? $"{currentMonster.Name} (HP: {currentMonster.HP}, 공격력: {currentMonster.Attack})"
                    : $"{currentMonster.Name}이(가) 나타났다!";
            }
            else
            {
                lblMonsterStatus.Text = "현재 몬스터 없음";
            }
        }


        private void UpdateMonsterStatus()
        {
            if (currentMonster != null)
            {
                // 처음 등장한 몬스터일 경우
                if (!currentMonster.Encountered)
                {
                    lblMonsterStatus.Text = $"{currentMonster.Name}이(가) 나타났다! (체력: {currentMonster.HP}, 공격력: {currentMonster.Attack})";
                    currentMonster.Encountered = true; // 첫 등장 이후 상태 변경
                }
                else
                {
                    // 이미 등장한 몬스터의 상태
                    lblMonsterStatus.Text = $"{currentMonster.Name} (체력: {currentMonster.HP}, 공격력: {currentMonster.Attack})";
                }
            }
            else
            {
                lblMonsterStatus.Text = "현재 몬스터 없음";
            }
        }

        private void UpdateMonsterImage()
        {
            if (currentMonster == null)
            {
                pictureBoxMonster.Visible = false; 
                return;
            }

            // 몬스터 이름에 따라 이미지 파일 설정
            switch (currentMonster.Name)
            {
                case "슬라임":
                    pictureBoxMonster.Image = Properties.Resources.slime; 
                    break;
                case "고블린":
                    pictureBoxMonster.Image = Properties.Resources.goblin; 
                    break;
                case "마왕":
                    pictureBoxMonster.Image = Properties.Resources.boss;
                    break;
                case "스켈레톤":
                    pictureBoxMonster.Image = Properties.Resources.skeleton; 
                    break;
                case "오크":
                    pictureBoxMonster.Image = Properties.Resources.orc; 
                    break;
                default:
                    pictureBoxMonster.Image = null; 
                    break;
            }

            pictureBoxMonster.Visible = true; // 이미지 보이기
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblStory.Text = "당신의 이름을 알려주세요";
            lblStory.Visible = true;
            btnChoice1.Visible = false;
            btnChoice2.Visible = false;
            btnChoice3.Visible = false;  

            pictureBox1.Paint += new PaintEventHandler(pictureBox1_Paint);

            // 버튼 배경을 투명하게 설정
            btnChoice1.FlatStyle = FlatStyle.Flat;
            btnChoice1.BackColor = Color.Transparent;
            btnChoice1.FlatAppearance.BorderSize = 0;

            btnChoice2.FlatStyle = FlatStyle.Flat;
            btnChoice2.BackColor = Color.Transparent;
            btnChoice2.FlatAppearance.BorderSize = 0;

            btnChoice3.FlatStyle = FlatStyle.Flat;
            btnChoice3.BackColor = Color.Transparent;
            btnChoice3.FlatAppearance.BorderSize = 0;
        }
        private void ShowStory()
        {
            lblStory.Text = $"{playerName}님, 체력: {health} / 행동력: {stamina}";

            if (currentMonster != null) // 몬스터가 존재할 경우
            {
                if (!currentMonster.Encountered) // 몬스터가 처음 나타난 경우
                {
                    lblMonsterStatus.Text = $"{currentMonster.Name} (체력: {currentMonster.HP}, 공격력: {currentMonster.Attack})";
                    currentMonster.Encountered = true; // 첫 등장 이후 상태 변경
                    UpdateMonsterImage(); // 몬스터 등장 시 이미지 업데이트
                }
                else // 이미 등장한 몬스터의 상태 표시
                {
                    lblMonsterStatus.Text = $"{currentMonster.Name} (체력: {currentMonster.HP}, 공격력: {currentMonster.Attack})";
                }

                // 전투 시 선택지 설정
                btnChoice1.Text = "싸운다.";
                btnChoice2.Text = "도망간다.";
                btnChoice3.Visible = false;  // 전투 상황에서는 회복 버튼을 숨김
            }
            else // 몬스터가 없는 경우 기본 스토리 표시
            {
                int randomIndex = storyRandomizer.Next(story.Count);
                lblMonsterStatus.Text = $"{story[randomIndex]}";
                btnChoice1.Text = choices[0];
                btnChoice2.Text = choices[1];
                btnChoice3.Visible = true;  // 몬스터가 없을 때 회복 버튼을 보임
            }

            btnChoice1.Visible = true;  
            btnChoice2.Visible = true; 
        }

        private void HandleChoice(int choice)
        {
            diceResult = diceRoll.Next(1, 7);

            if (currentMonster == null)
            {
                SummonMonster();
                UpdateStatusDisplay();
            }
            else if (choice == 1) // 싸운다
            {
                if (stamina > 2)
                {
                    stamina -= 2;
                    int playerDamage = 15;
                    currentMonster.HP -= playerDamage;
                    lblResult.Text = $"주사위 결과: {diceResult}. {currentMonster.Name}에게 {playerDamage}의 데미지를 입혔다!";

                    if (currentMonster.HP <= 0)
                    {
                        lblResult.Text += $" {currentMonster.Name}을(를) 물리쳤다!";
                        monstersDefeated++;

                        if (currentMonster.Name == "마왕")
                        {
                            MessageBox.Show("축하합니다! 마왕을 물리치고 엔딩에 도달했습니다.");
                            Application.Exit();
                        }
                        else
                        {
                            currentMonster = null;
                            ShowStory();
                        }
                    }
                    else
                    {
                        int monsterDamage = currentMonster.Attack;
                        health -= monsterDamage;
                        lblResult.Text += $" {currentMonster.Name}이(가) {monsterDamage}의 피해를 입혔다!";
                        if (health <= 0) GameOver();
                    }
                }
                else
                {
                    lblResult.Text = "행동력이 부족하여 싸울 수 없습니다.";
                }
            }
            else if (choice == 2) // 도망
            {
                if (stamina > 5)
                {
                    stamina -= 10;
                    lblResult.Text = $"주사위 결과: {diceResult}. 도망 성공! 몬스터 카운터 초기화됨.";
                    monstersDefeated = 0;
                    currentMonster = null;
                    ShowStory();
                }
                else
                {
                    lblResult.Text = "행동력이 부족하여 도망갈 수 없습니다.";
                }
            }

            UpdateStatusDisplay();
            pictureBox1.Invalidate();
        }

        private void btnChoice1_Click(object sender, EventArgs e)
        {
            HandleChoice(1);
        }

        private void btnChoice2_Click(object sender, EventArgs e)
        {
            HandleChoice(2);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            playerName = txtName.Text;
            if (!string.IsNullOrEmpty(playerName))
            {
                txtName.Visible = false;
                btnStart.Visible = false;
                lblStory.Text = $"{playerName}님, 비주얼 노벨을 시작합니다!";
                btnChoice1.Visible = true;
                btnChoice2.Visible = true;
                ShowStory();
            }
            else
            {
                MessageBox.Show("이름을 입력해주세요.");
            }
        }

        private void GameOver()
        {
            MessageBox.Show("게임 오버! 체력이 0이 되었습니다.");
            Application.Exit();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // 주사위 숫자
            // lblResult의 위치 기준으로 주사위의 위치 설정
            int lblResultX = lblResult.Location.X;
            int lblResultY = lblResult.Location.Y;

            // 주사위 그리기 (각 숫자에 맞는 주사위 그림)
            switch (diceResult)
            {
                case 1:
                    // 주사위 1 그리기
                    Graphics g = e.Graphics;
                    Pen p = new Pen(Color.Green, 5);
                    Rectangle rc1 = new Rectangle(lblResultX + 10, lblResultY + 50, 100, 100); 
                    g.DrawRectangle(p, rc1);
                    Brush b = new SolidBrush(Color.Green);
                    Rectangle rc2 = new Rectangle(lblResultX + 35, lblResultY + 70, 50, 50);
                    g.FillEllipse(b, rc2);
                    break;
                case 2:
                    // 주사위 2 그리기
                    g = e.Graphics;
                    p = new Pen(Color.Green, 5);
                    rc1 = new Rectangle(lblResultX + 10, lblResultY + 50, 100, 100);
                    g.DrawRectangle(p, rc1);
                    b = new SolidBrush(Color.Green);
                    rc2 = new Rectangle(lblResultX + 30, lblResultY + 70, 25, 25);
                    Rectangle rc3 = new Rectangle(lblResultX + 70, lblResultY + 110, 25, 25);
                    g.FillEllipse(b, rc2);
                    g.FillEllipse(b, rc3);
                    break;
                case 3:
                    // 주사위 3 그리기
                    g = e.Graphics;
                    p = new Pen(Color.Green, 5);
                    rc1 = new Rectangle(lblResultX + 10, lblResultY + 50, 100, 100);
                    g.DrawRectangle(p, rc1);
                    b = new SolidBrush(Color.Green);
                    rc2 = new Rectangle(lblResultX + 30, lblResultY + 60, 25, 25);
                    rc3 = new Rectangle(lblResultX + 70, lblResultY + 120, 25, 25);
                    Rectangle rc4 = new Rectangle(lblResultX + 50, lblResultY + 90, 25, 25);
                    g.FillEllipse(b, rc2);
                    g.FillEllipse(b, rc3);
                    g.FillEllipse(b, rc4);
                    break;
                case 4:
                    // 주사위 4 그리기
                    g = e.Graphics;
                    p = new Pen(Color.Green, 5);
                    rc1 = new Rectangle(lblResultX + 10, lblResultY + 50, 100, 100);
                    g.DrawRectangle(p, rc1);
                    b = new SolidBrush(Color.Green);
                    rc2 = new Rectangle(lblResultX + 30, lblResultY + 70, 25, 25);
                    rc3 = new Rectangle(lblResultX + 70, lblResultY + 70, 25, 25);
                    rc4 = new Rectangle(lblResultX + 30, lblResultY + 110, 25, 25);
                    Rectangle rc5 = new Rectangle(lblResultX + 70, lblResultY + 110, 25, 25);
                    g.FillEllipse(b, rc2);
                    g.FillEllipse(b, rc3);
                    g.FillEllipse(b, rc4);
                    g.FillEllipse(b, rc5);
                    break;
                case 5:
                    // 주사위 5 그리기
                    g = e.Graphics;
                    p = new Pen(Color.Green, 5);
                    rc1 = new Rectangle(lblResultX + 10, lblResultY + 50, 100, 100);
                    g.DrawRectangle(p, rc1);
                    b = new SolidBrush(Color.Green);
                    rc2 = new Rectangle(lblResultX + 25, lblResultY + 60, 25, 25);
                    rc3 = new Rectangle(lblResultX + 75, lblResultY + 60, 25, 25);
                    rc4 = new Rectangle(lblResultX + 25, lblResultY + 120, 25, 25);
                    rc5 = new Rectangle(lblResultX + 75, lblResultY + 120, 25, 25);
                    Rectangle rc6 = new Rectangle(lblResultX + 50, lblResultY + 90, 25, 25);
                    g.FillEllipse(b, rc2);
                    g.FillEllipse(b, rc3);
                    g.FillEllipse(b, rc4);
                    g.FillEllipse(b, rc5);
                    g.FillEllipse(b, rc6);
                    break;
                case 6:
                    // 주사위 6 그리기
                    g = e.Graphics;
                    p = new Pen(Color.Green, 5);
                    rc1 = new Rectangle(lblResultX + 10, lblResultY + 50, 100, 100);
                    g.DrawRectangle(p, rc1);
                    b = new SolidBrush(Color.Green);
                    rc2 = new Rectangle(lblResultX + 25, lblResultY + 60, 25, 25);
                    rc3 = new Rectangle(lblResultX + 75, lblResultY + 60, 25, 25);
                    rc4 = new Rectangle(lblResultX + 25, lblResultY + 120, 25, 25);
                    rc5 = new Rectangle(lblResultX + 75, lblResultY + 120, 25, 25);
                    rc6 = new Rectangle(lblResultX + 25, lblResultY + 90, 25, 25);
                    Rectangle rc7 = new Rectangle(lblResultX + 75, lblResultY + 90, 25, 25);
                    g.FillEllipse(b, rc2);
                    g.FillEllipse(b, rc3);
                    g.FillEllipse(b, rc4);
                    g.FillEllipse(b, rc5);
                    g.FillEllipse(b, rc6);
                    g.FillEllipse(b, rc7);
                    break;
            }
        }

        private void btnChoice3_Click(object sender, EventArgs e)
        {
            if (health < 100)  // 체력이 100 미만일 때만 회복
            {
                health += 20; // 체력 20 증가
                if (health > 100)
                {
                    health = 100;  // 최대 체력 100을 넘지 않도록 제한
                }
                lblResult.Text = $"{playerName}님의 체력이 회복되었습니다! 현재 체력: {health}";

                UpdateStatusDisplay(); // 체력 상태 업데이트
            }
            else
            {
                lblResult.Text = $"{playerName}님의 체력이 이미 최대입니다."; // 체력이 이미 최대일 경우
            }
        }
    }
    public class Monster
    {
        public string Name { get; set; }
        public int HP { get; set; }
        public int Attack { get; set; }
        public bool Encountered { get; set; } = false;

        public Monster(string name, int hp, int attack)
        {
            Name = name;
            HP = hp;
            Attack = attack;
        }
    }
}
