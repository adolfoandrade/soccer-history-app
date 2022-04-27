function TimeLineCardComponent(props) {
    const StyledTimeLineCard = {
        border: "solid 1px #bdbdbd",
        borderRadius: "10px",
        maxWidth: "500px",
        margin: "0 auto 1rem auto",
    };
    return (
        <div className="time-line-card" style={StyledTimeLineCard}>
            <div
                className="time-line-card-header"
                style={{
                    borderBottom: "solid 1px #bdbdbd",
                    display: "flex",
                    flexDirection: "row",
                    alignItems: "center",
                    padding: "20px",
                    flexWrap: "wrap",
                }}
            >
                <div style={{ margin: "0 auto", fontWeight: "600", flexGrow: 1 }}>
                    <img
                        alt=""
                        src="https://ssl.gstatic.com/onebox/sports/game_feed/yellow_card_icon.svg"
                    />
                </div>
                <div
                    style={{ margin: "0 auto", fontWeight: "500", flexGrow: 10 }}
                >
                    {props.item?.item?.color} CARD
                </div>
                <div
                    style={{
                        margin: "0 auto",
                        fontWeight: "500",
                        color: "#757575",
                        flexGrow: 1,
                    }}
                >
                    {props.item?.item?.minute}'
                </div>
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

export default TimeLineCardComponent;