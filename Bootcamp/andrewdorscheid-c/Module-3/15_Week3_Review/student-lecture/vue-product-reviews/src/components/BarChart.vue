<template>
  <div class="chart">
    <div
      class="bar"
      v-for="(bar, ix) in chartData"
      :key="bar.id"
      :style="{height: heightPercent(bar.value), 'background-color': backgroundColor(bar, ix)}"
      :title="`${bar.label}: ${bar.value}`"
    >{{bar.label}}</div>
  </div>
</template>

<script>
export default {
  props: {
    // chartData is an array of items which contain properties (id, label and value)
    chartData: {
      type: Array,
      required: true,
    },
    scale: Number,
    colors: {
      type: Array,
      default: () => [
        "lightblue",
        "lightgreen",
        "lightyellow",
        "lightgray",
        "lightpink",
        "blue",
        "green",
        "yellow",
        "gray",
        "yellowgreen",
      ],
    },
  },
  computed: {
    computedScale() {
      if (this.scale) return this.scale;
      return this.chartData.reduce((max, ele) => Math.max(max, ele.value), 0);
    },
  },
  methods: {
    heightPercent(height) {
      return (height * 100) / this.computedScale + "%";
    },
    backgroundColor(bar, ix) {
      return bar.color ? bar.color : this.colors[ix % this.colors.length];
    },
  },
};
</script>

<style>
.chart {
  display: flex;
  flex-direction: row;
  align-items: flex-end;
  min-height: 50px;
  height: 1px;
}
.bar {
  width: 1px;
  flex-grow: 1;
  line-height: 2em;
  border: 1px solid gray;
}
</style>