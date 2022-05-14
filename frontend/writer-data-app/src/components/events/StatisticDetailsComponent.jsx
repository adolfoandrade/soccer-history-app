function StatistcDetailsComponent(props) {
    const StyledTimeLineCard = {
        border: "solid 1px #bdbdbd",
        borderRadius: "10px",
        maxWidth: "500px",
        margin: "0 auto 1rem auto",
        justifyContent: "center",
    };
    return (
        <div className="time-line-card" style={StyledTimeLineCard}>
            <table style={{ width: "100%" }}>
                <tr>
                    <th><img alt="" src={`${props.item?.home?.image}`} width="24" /></th>
                    <th style={{ width: "80%" }}>TEAM STATS</th>
                    <th><img alt="" src={`${props.item?.out?.image}`} width="24" /></th>
                </tr>
                <tr>
                    <td>0</td>
                    <td>Shots</td>
                    <td>0</td>
                </tr>
                <tr>
                    <td>0</td>
                    <td>Shots on target</td>
                    <td>0</td>
                </tr>
            </table>
        </div>
    );
}

export default StatistcDetailsComponent;