<script setup lang="ts">
  import { useAppFakePage } from '~/utils/domain/app/pages/fake/app-fake-page.composable'

  const { key, click, clickCount } = useAppFakePage()
</script>

<template>
  <div>
    {{ key }}
    <br>
    [<button @click="click">Clicked {{ clickCount }} times</button>]
  </div>
</template>
