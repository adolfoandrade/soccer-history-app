function TimeLineGoalComponent(props) {
    const StyledTimeLineCard = {
        border: "solid 1px #bdbdbd",
        borderRadius: "10px",
        maxWidth: "500px",
        margin: "0 auto 1rem auto",
        overflow: "hidden",
      };

    return (
        <div style={StyledTimeLineCard}>
        <div style={{
          borderBottom: "solid 1px #bdbdbd",
          padding: "20px",
          flexWrap: "wrap",
          backgroundColor: props.item?.soccerTeam?.colorTheme
        }}>
          <div style={{
            width: "30px",
            margin: "0 auto",
          }}>
            <img className="oeEknf" src="https://ssl.gstatic.com/onebox/sports/game_feed/goal_icon.svg" alt="" />
          </div>
          <div style={{
            width: "120px",
            margin: "0 auto",
          }}>GOOOAAALLL!!!</div>
          <div style={{
            width: "20px",
            margin: "0 auto",
          }}>{props.item?.item?.minute}'</div>
        </div>
        <div style={{ display: "flex", alignItems: "center" }}>
          <div
            style={{
              margin: "0 auto",
              fontWeight: "600",
              flexGrow: 1,
              padding: "20px",
            }}
          >
            {props.item?.item?.player}
          </div>
          <div
            style={{
              margin: "0 auto",
              fontWeight: "600",
              flexGrow: 1,
              padding: "20px",
            }}
          >
            <img
              alt=""
              src={props.item?.soccerTeam?.image}
              width="56"
              height="56"
              style={{ float: "right" }}
            />
          </div>
        </div>
      </div>
    );
  }
  
  export default TimeLineGoalComponent;