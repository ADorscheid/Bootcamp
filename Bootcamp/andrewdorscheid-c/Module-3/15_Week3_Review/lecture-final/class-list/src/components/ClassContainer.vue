<template>
<div class="container">
    <h1>.NET Summer 2020 [14]</h1>
  <!-- two charts here -->
    <bar-chart class="age-chart" :chartData="ageChartData" />

    <!-- Add person form -->

    <!-- Class list -->
    <class-list />

</div>
</template>

<script>
import ClassList from './ClassList.vue'
import BarChart from './BarChart.vue'

export default {
    components: {
        ClassList,
        BarChart
    },
    computed:{
        ageChartData(){
            let cd = this.$store.state.people.map( person => {
                return { id: person.id,
                        label: `${person.name} (${person.height})`,
                        value: person.height};
            });
            return cd.sort((e1, e2)=>{
                return e2.value - e1.value;
            });
        }
    }

}
</script>

<style scoped>
.container {
    margin: 0 auto;
}
.age-chart {
    height: 200px;
    width: 800px;
}
</style>