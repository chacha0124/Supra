# Supra

1. Door
  1) DoorControl
     문을 열고 닫는 스크립트입니다.
     HandScanner를 통해 문을 열고, 일정 시간 뒤 문 범위 내에 플레이어가 없다면 문을 닫습니다.
  3) HandScanner
     문을 제어하는 스크립트입니다.
     문의 종류에 따라 문을 열어주거나 잠겨있음을 알려줍니다.
     게임의 진행에 관련된 문을 열었을 때는 EventManager를 통해 게임 진행에 관련된 메서드를 호출합니다.

2. Fire
   1) Extinguisher
      소화기 스크립트입니다.
      화재 발생 공간에 소화기를 던질 경우 화재를 진화합니다.
   2) Fire
      화재 스크립트입니다.
      불이 붙었을 때나 꺼졌을 때 불의 크기를 조절합니다.
   3) Hittable
      불이 불었을 때나 꺼졌을 때 이벤트 호출을 위한 스크립트입니다.

  3. Managers
     1) GameManager
        게임의 시작과 엔딩에 관련된 기능을 담당하는 스크립트입니다.
     2) EventManager
        게임 내에서 발생하는 이벤트를 관리하는 스크립트입니다.
        EventIndex로 이벤트 발생 순서를 관리하여 게임이 기획한 순서대로 흘러가도록 도와줍니다.
     3) TutorialImageManager
        게임 시작 시 컨트롤러 조작에 관한 튜토리얼 이미지를 띄워주는 스크립트입니다.
     4) UIManager
        메인 메뉴에서 버튼 클릭 시 버튼 활성화/비활성화와 오디오 관련 설정 변경을 담당하는 스크립트입니다.

    4. Player
      1) Player
        플레이어의 상호작용을 담당하는 스크립트입니다.
        Update에서 Raycast를 통해 객체를 감지하고 해당 객체의 태그에 맞는 함수를 호출합니다.

    5. Puzzle
      1) ControlStationPuzzleSpaceship
        항해실 퍼즐의 우주선 스크립트입니다.
        우주선이 길을 따라 목적지까지 갈 수 있는지를 체크합니다.
      2) ControlStationPuzzleSocket
        항해실 퍼즐의 퍼즐조각 스크립트입니다.
        퍼즐조각의 회전을 도와주는 함수가 있습니다.
      3) ControlStationPuzzleButton
        항해실 퍼즐의 시작 버튼 스크립트입니다.
        해당 버튼을 눌러 우주선을 움직일 수 있습니다.
