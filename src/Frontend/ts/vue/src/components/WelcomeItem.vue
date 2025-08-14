<script setup lang="ts">
import { computed, reactive, ref, toRefs, watch, watchEffect } from 'vue'

interface Named {
  name: string
}

const a: Named = { name: '1111111111' }

const e = reactive<Named>(a)

console.log('Named', e)

const props = defineProps<{ name: string }>()

console.log('props', props)

const { name } = toRefs(props) // 1
//const name = computed(() => props.name) // 2
//const name = ref(props.name) // 3

const title = ref('2222222')

watchEffect(() => {
  console.log('watchEffect:props.name', props.name)
  console.log('watchEffect:title', title.value)
})

watch(name, () => {
  console.log('watch:name', name.value)
})

watch(title, () => {
  console.log('watch:title', title.value)
})
</script>
<template>
  <h1>name: {{ name }}</h1>
  <h1>title: {{ title }}</h1>
  <label for="title">title:</label>
  <input id="title" type="text" v-model="title" />
</template>
