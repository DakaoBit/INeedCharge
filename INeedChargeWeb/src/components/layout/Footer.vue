<template>
    <footer style="height:150px" class="footer">
    <div class="tabs is-toggle is-fullwidth">
        <ul>
            <li class="is-active"> 
                <a @click="$emit('update:modelValue', 1)">
                    <span class="icon is-small">
                        <i class="fa-solid fa-map" aria-hidden="true"></i>
                    </span>
                    <span>導航</span>
                </a>
            </li>
            <li>
                <a @click="$emit('update:modelValue', 2)">
                    <span class="icon is-small">
                        <i class="fa-solid fa-charging-station" aria-hidden="true"></i>
                    </span>
                    <span>國道充電站資訊</span>
                </a>
            </li>
            <li>
                <a @click="$emit('update:modelValue', 3)">
                    <span class="icon is-small">
                        <i class="fa-solid fa-file-invoice-dollar" aria-hidden="true"></i>
                    </span>
                    <span>即時費率</span>
                </a>
            </li>
        </ul>
    </div>
</footer>
</template>
<script>
    export default {
        comqponent: {
            name: 'Footer'
        },
        emits: ['modelValue'],
    }
</script>
