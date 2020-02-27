<template>
  <div id="home">
    <mt-swipe :auto="4000" style="height:200px;">
      <mt-swipe-item v-for='(item,index) in imgs' :key=index>
        <img :src="item" alt="">
      </mt-swipe-item>

    </mt-swipe>
  </div>

</template>

<script>
  export default {
    name: 'Home',
    data() {
      return {
        imgs: ['https://ask-fd.zol-img.com.cn/g5/M00/0B/0C/ChMkJln1KkWIZtSgAAPXvqZ9FskAAhpyAElcFYAA9fW696.jpg'
          , 'http://xa.qizuang.com/upload/editor/image/20150724/20150724102002_74065.png']
      }
    },
    created() {
      this.$axios.get('')
        .then(res => {
          console.log(imgs);
          //this.imgs=res.data.message;
        })
        .catch(err => {
          console.log(err)
        })
    },
  }
</script>

<style lang="css" scoped>

</style>